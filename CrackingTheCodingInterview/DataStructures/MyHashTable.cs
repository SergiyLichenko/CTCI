using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyHashTable<TKey, TValue>
    {
        private LinkedList<LinkedListNode<TKey, TValue>>[] _map;

        public MyHashTable()
        {
            _map = new LinkedList<LinkedListNode<TKey, TValue>>[3];
        }

        public TValue this[TKey key]
        {
            get
            {
                var index = Math.Abs(key.GetHashCode() % _map.Length);
                if (!ContainsKey(key))
                    throw new KeyNotFoundException();
                return _map[index].First(x => x.Key.Equals(key)).Value;
            }
            set
            {
                var index = Math.Abs(key.GetHashCode() % _map.Length);

                if (ContainsKey(key))
                    _map[index].First(x => x.Key.Equals(key)).Value = value;
                else
                    Add(key, value);
            }
        }

        public int Count { get; private set; }

        public void Add(TKey key, TValue value)
        {
            if(ContainsKey(key))
                throw new ArgumentException();

            Count++;
            var index = Math.Abs(key.GetHashCode() % _map.Length);

            if (_map[index] == null)
                _map[index] = new LinkedList<LinkedListNode<TKey, TValue>>();

            _map[index].AddLast(new LinkedListNode<TKey, TValue>() { Key = key, Value = value });
        }

        public bool ContainsKey(TKey key)
        {
            var index = Math.Abs(key.GetHashCode() % _map.Length);
            if (_map[index] == null)
                return false;
            return _map[index].FirstOrDefault(x => x.Key.Equals(key)) != null;
        }

        public bool ContainsValue(TValue value)
            => _map.Where(x => x != null).SelectMany(x => x.Select(y => y.Value)).FirstOrDefault(x => x.Equals(value)) != null;


        public IEnumerator GetEnumerator() => _map.GetEnumerator();

        public void Clear()
        {
            Count = 0;
            foreach (var linkedListNodes in _map)
                linkedListNodes?.Clear();
        }

        public bool Remove(TKey key)
        {
            if (!ContainsKey(key))
                return false;

            var index = Math.Abs(key.GetHashCode() % _map.Length);
            var node = _map[index].First(x => x.Key.Equals(key));
            _map[index].Remove(node);

            Count--;
            return true;
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);
            if (!ContainsKey(key))
                return false;

            value = this[key];
            return true;
        }

        private sealed class LinkedListNode<TKey, TValue>
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }
    }
}
