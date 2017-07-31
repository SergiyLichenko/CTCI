using System;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace DataStructures
{
    public class MyStringBuilder
    {
        private char[] _mass;
        private int _length;
        public char this[int index]
        {
            get
            {
                if(index < 0 || index>= _mass.Length)
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
            if(capacity < 0)
                throw new ArgumentOutOfRangeException();
            _mass = new char[capacity];
        }

        public MyStringBuilder(string value)
        {
            _mass = value.ToCharArray();
            _length = _mass.Length;
        }

        public MyStringBuilder Append(string value)
        {
            if (_length + value.Length <= Capacity)
            {
                var temp = new char[_mass.Length * 2];

                Array.Copy(_mass, temp, _mass.Length);
                _mass = temp;
            }

            Array.Copy(value.ToCharArray(),0, _mass,_length, value.Length);
            _length += value.Length;
            return this;
        }

        public int Capacity => _mass.Length;
        public int Length => _length;

        public override string ToString()
        {
            return String.Join("", _mass);
        }
    }
}
