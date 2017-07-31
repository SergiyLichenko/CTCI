using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace DataStructures
{
    public class MyStringBuilder
    {
        private char[] _mass;
        private int _length;
        public int Capacity => _mass.Length;
        public int Length => _length;

        public char this[int index]
        {
            get
            {
                if (index < 0 || index >= _mass.Length)
                    throw new ArgumentOutOfRangeException();
                return _mass[index];
            }
            set
            {
                if (index < 0 || index >= _mass.Length)
                    throw new ArgumentOutOfRangeException();
                _mass[index] = value;
            }
        }

        public MyStringBuilder()
        {
            _mass = new char[4];
        }

        public MyStringBuilder(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException();
            _mass = new char[capacity];
        }

        public MyStringBuilder(string value)
        {
            _mass = value.ToCharArray();
            _length = _mass.Length;
        }

        public MyStringBuilder Append(string value) => Insert(_length, value);

        public MyStringBuilder Clear()
        {
            Array.Clear(_mass, 0, _length);
            _length = 0;

            return this;
        }

        public void CopyTo(int sourceIndex, char[] destination, int destinationIndex, int count)
        {
            if (sourceIndex < 0 || sourceIndex > _length)
                throw new ArgumentOutOfRangeException();
            if (destination == null)
                throw new ArgumentNullException();
            if (destinationIndex < 0 || destinationIndex > destination.Length)
                throw new ArgumentOutOfRangeException();

            Array.Copy(_mass, sourceIndex, destination, destinationIndex, count);
        }

        public override string ToString()
        {
            return String.Join("", _mass.Take(_length));
        }

        public bool Equals(MyStringBuilder sb)
        {
            if (sb == null)
                throw new ArgumentNullException();
            if (sb.Length != Length)
                return false;

            for (int i = 0; i < Length; i++)
                if (sb[i] != _mass[i])
                    return false;
            return true;
        }

        public MyStringBuilder Insert(int startIndex, string value)
        {
            if (startIndex < 0 || startIndex > Length)
                throw new ArgumentOutOfRangeException();
            if (value == null)
                throw new ArgumentNullException();

            while (_length + value.Length > Capacity)
            {
                var temp = new char[_mass.Length * 2];

                Array.Copy(_mass, temp, _mass.Length);
                _mass = temp;
            }

            for (int i = _length - 1; i >= startIndex; i--)
                _mass[i + value.Length] = _mass[i];
            for (int i = startIndex; i < startIndex + value.Length; i++)
                _mass[i] = value[i - startIndex];
            _length += value.Length;

            return this;
        }

        public MyStringBuilder Replace(string oldValue, string newValue)
        {
            if (oldValue == null || newValue == null)
                throw new ArgumentNullException();

            var my = ToString();
            _mass = my.Replace(oldValue, newValue).ToCharArray();
            _length = _mass.Length;

            return this;
        }

        public MyStringBuilder Remove(int startIndex, int length)
        {
            if (startIndex < 0 || startIndex > _length || startIndex + length > _length)
                throw new ArgumentOutOfRangeException();

            for (int i = startIndex; i < startIndex + length && i + length < _length; i++)
                _mass[i] = _mass[i + length];
            _length -= length;
            for (int i = _mass.Length - 1; i >= _length; i--)
                _mass[i] = '\0';

            return this;
        }
    }
}
