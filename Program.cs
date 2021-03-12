using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework_Lesson_14
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = new MyList<int>();
            myList.Add(1);
            var t = myList.Count;
            Console.WriteLine(myList[0]);
            var dictionary = new MyDictionary<int, string>();
            dictionary.Add(1, "name");
            Console.WriteLine(dictionary[1]);
        }
    }

    public class MyList<T>
    {
        private T[] _values = Array.Empty<T>();
        private int _i = 0; 
        public T this[int index]
        {
            get => _values[index];
            set => _values[index] = value;
        }
        public void Add(T value)
        {
            Array.Resize(ref _values, _i + 1);
            _values[_i] = value;
            _i++;
        }
        public int Count => _i;

    }
    public class MyDictionary<TKey, TValue>
    {
        private MyList<TKey> _keys = new();
        private MyList<TValue> _values = new();

        public void Add(TKey key, TValue value)
        {
            _keys.Add(key);
            _values.Add(value);
        }

        public TValue Get(TKey key)
        {
            int keyIndex;
            for (int i = 0; i < _keys.Count; i++)
            {
                if (_keys[i].Equals(key))
                {
                    keyIndex = i;
                    return _values[keyIndex];
                }
            }
            return (TValue)(object)null;
        }

        public TValue this[TKey key]
        {
            get
            {
                for (int i = 0; i < _keys.Count; i++)
                {
                    if (_keys[i].Equals(key))
                    {
                        return _values[i];
                    }
                }
                return (TValue)(object)null;
            }
            set
            {
                for (int i = 0; i < _keys.Count; i++)
                {
                    if (_keys[i].Equals(key))
                    {
                        _values[i] = value;
                        return;
                    }
                }
            }
        }
    }

}