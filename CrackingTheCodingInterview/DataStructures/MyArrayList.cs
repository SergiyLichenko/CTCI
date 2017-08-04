using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyArrayList : ICloneable, IList
    {
        private const int DefaultCapacity = 4;
        private object[] _items;
        private int _topIndex;

        public int Count { get; private set; }
        public int Capacity => _items.Length;
        public object SyncRoot { get; }
        public bool IsSynchronized { get; } = false;
        public bool IsReadOnly { get; } = false;
        public bool IsFixedSize { get; } = false;


        public object this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException();
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException();
                _items[index] = value;
            }
        }

        public MyArrayList()
        {
            _items = new object[DefaultCapacity];
        }

        public MyArrayList(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException();
            _items = new object[capacity];
        }

        public MyArrayList(IEnumerable<object> items)
        {
            if (items == null)
                throw new ArgumentNullException();

            _items = new object[items.Count()];
            AddRange(items);
        }

        public void Add(object item)
        {
            Insert(_topIndex, item);
        }

        public void Insert(int index, object value)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException();
            if (Count == _items.Length)
            {
                var newItems = new object[_items.Length * 2];
                for (int i = 0; i < _items.Length; i++)
                    newItems[i] = _items[i];
                _items = newItems;
            }
            for (int i = _topIndex - 1; i >= index; i--)
                _items[i + 1] = _items[i];
            _items[index] = value;
            _topIndex++;
            Count++;
        }


        public void InsertRange(int index,
            IEnumerable<object> collection)
        {
            if (index < 0 || index > Count)
                throw new ArgumentOutOfRangeException();
            if (collection == null)
                throw new ArgumentNullException();

            var collectionCount = collection.Count();

            while (Count + collectionCount > Capacity)
            {
                var newItems = new object[_items.Length * 2];
                for (int i = 0; i < _items.Length; i++)
                    newItems[i] = _items[i];
                _items = newItems;
            }
            for (int i = _topIndex - 1; i >= index; i--)
                _items[i + collectionCount] = _items[i];
            for (int i = 0; i < collectionCount; i++)
                _items[index + i] = collection.ElementAt(i);
            _topIndex += collectionCount;
            Count += collectionCount;
        }

        public void AddRange(IEnumerable<object> collection)
        {
            InsertRange(_topIndex, collection);
        }

        public int BinarySearch(object value)
            => BinarySearch(value, 0, Count - 1);

        public int BinarySearch(object value, int startIndex, int endIndex)
        {
            if (value == null) throw new ArgumentNullException();
            if (!(value is IComparable)) return -1;
            if (startIndex < 0 || startIndex > endIndex ||
                endIndex >= Count)
                throw new ArgumentOutOfRangeException();

            var comparer = Comparer.Default;

            while (startIndex <= endIndex)
            {
                int middle = (startIndex + endIndex) / 2;

                var result = comparer.Compare(_items[middle], value);
                if (result == 0)
                    return middle;

                if (result > 0) //value is less
                    endIndex = middle - 1;
                else
                    startIndex = middle + 1;
            }

            return -1;
        }

        int IList.Add(object value)
        {
            Add(value);
            return Count - 1;
        }

        public void Clear()
        {
            for (int i = 0; i < _topIndex; i++)
                _items[i] = null;
            Count = 0;
        }

        public object Clone()
        {
            MyArrayList list = new MyArrayList(Capacity);
            list.AddRange(_items.Take(Count));
            return list;
        }

        public bool Contains(object value)
            => IndexOf(value) != -1;

        public int IndexOf(object value)
        {
            for (int i = 0; i < Count; i++)
                if ((value == null && _items[i] == null) ||
                    (_items[i] != null && _items[i].Equals(value)))
                    return i;
            return -1;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return _items[i];
        }

        public void CopyTo(Array array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (arrayIndex < 0 || arrayIndex >= array.Length ||
                array.Length - arrayIndex < Count)
                throw new ArgumentOutOfRangeException();

            for (int i = 0; i < Count; i++)
                array.SetValue(_items[i], i + arrayIndex);
        }

        public void RemoveAt(int index)
        {
            if(index<0 || index >=Count)
                throw new ArgumentOutOfRangeException();
            for (int i = index; i < Count-1; i++)
                _items[i] = _items[i + 1];
            _items[Count - 1] = null;
            Count--;
        }

        public void Remove(object value)
        {
            var index = IndexOf(value);
            if (index == -1)
                return;
            RemoveAt(index);
        }
    }
}
