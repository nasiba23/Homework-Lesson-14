using System;

namespace Homework_Lesson_14
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new DictionaryImitation<int, string>();
            dictionary.Add(1, "name");
            var val = dictionary.Get(1);
            Console.WriteLine(val);
            var removed = dictionary.Remove(1);
            Console.WriteLine(removed);
        }
    }
    public class DictionaryImitation<TKey, TValue>
    {
        private TKey[] _keys = Array.Empty<TKey>();
        private TValue[] _values = Array.Empty<TValue>();

        private int _i;
        
        public void Add(TKey key, TValue value)
        {
            Array.Resize(ref _keys, _i + 1);
            Array.Resize(ref _values, _i + 1);
            _keys[_i] = key;
            _values[_i] = value;
            _i++;
        }

        public TValue Get(TKey key)
        {
            int keyIndex;
            for (int i = 0; i < _keys.Length; i++)
            {
                if (_keys[i].Equals(key))
                {
                    keyIndex = i;
                    return _values[keyIndex];
                }
            }
            return (TValue)(object)null;
        }
        public bool Remove(TKey key)
        {
            int keyIndex = -1;
            var newKeys = Array.Empty<TKey>();
            var newValues = Array.Empty<TValue>();
            for (int i = 0; i < _keys.Length; i++)
            {
                if (_keys[i].Equals(key))
                {
                    keyIndex = i;
                    Array.Resize(ref newKeys, _keys.Length - 1);
                    Array.Resize(ref newValues, _values.Length - 1);
                }
            }

            if (keyIndex == -1)
            {
                return false;
            }

            for (int i = 0, j = 0; i < _keys.Length; i++)
            {
                if (i == keyIndex)
                {
                    continue;
                }
                newKeys[j] = _keys[i];
                newValues[j] = _values[i];
                j++;
            }
            _keys = newKeys;
            _values = newValues;
            return true;
        }
    }

}