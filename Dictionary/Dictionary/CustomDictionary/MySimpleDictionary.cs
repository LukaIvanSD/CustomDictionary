using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.VisualBasic;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using static MudBlazor.Colors;

namespace Dictionary.CustomDictionary
{
    public class MySimpleDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        public int Count = 0;

        public ICollection Keys
        {
            get
            {
                List<TKey> keys = new List<TKey>();
                foreach (List<Entry> bucket in buckets)
                {
                    if (bucket != null)
                    {
                        foreach (Entry entry in bucket)
                        {
                            keys.Add(entry.Key);
                        }
                    }
                }

                return keys;
            }
        }

        public ICollection Values
        {
            get
            {
                List<TValue> values = new List<TValue>();
                foreach (List<Entry> bucket in buckets)
                {
                    if (bucket != null)
                    {
                        foreach (Entry entry in bucket)
                        {
                            values.Add(entry.Value);
                        }
                    }
                }
                return values;
            }
        }

        private int DefaultCapacity = 3;
        private List<Entry>[] buckets;

        public MySimpleDictionary()
        {
            buckets = new List<Entry>[DefaultCapacity];
        }
        public MySimpleDictionary(int capacity)
        {
            buckets = new List<Entry>[capacity];
        }
        public MySimpleDictionary(IDictionary<TKey, TValue> dictionary)
        {
            buckets = new List<Entry>[DefaultCapacity];
            foreach (var kvp in dictionary)
            {
                Add(kvp.Key, kvp.Value);
            }
        }
        public bool Add(TKey key, TValue value)
        {
            uint hashCode = (uint)key.GetHashCode();
            uint bucketIndex = GetBucket(hashCode);
            Entry newEntry = new Entry
            {
                Key = key,
                Value = value
            };
            if (buckets[bucketIndex] == null)
            {
                buckets[bucketIndex] = new List<Entry>(1);
            }
            else
            {
                foreach (Entry entry in buckets[bucketIndex])
                {
                    if (entry.Key.Equals(key))
                    {
                        return false;
                    }
                }
            }
            buckets[bucketIndex].Add(newEntry);
            Count++;
            if ((float)Count / buckets.Length > 0.7)
            {
                Resize();
            }
            return true;
        }
        public TValue? this[TKey key]
        {
            get
            {
                return TryGetValue(key);
            }
            set
            {
                uint hashCode = (uint)key.GetHashCode();
                uint bucketIndex = GetBucket(hashCode);
                if (buckets[bucketIndex] == null)
                {
                    Add(key, value);
                }
                else
                {
                    for (int i = 0; i < buckets[bucketIndex].Count; i++)
                    {
                        if (buckets[bucketIndex][i].Key.Equals(key))
                        {
                            buckets[bucketIndex][i] = new Entry() { Key = key, Value = value };
                            return;
                        }
                    }
                    Add(key, value);
                }
            }
        }

        private void Resize()
        {
            List<Entry>[] oldBuckets = buckets;
            buckets = new List<Entry>[HashHelper.ExpandPrime(buckets.Length)];
            foreach (List<Entry> bucket in oldBuckets)
            {
                if (bucket != null)
                {
                    foreach (Entry entry in bucket)
                    {
                        uint hashCode = (uint)entry.Key.GetHashCode();
                        uint newBucketIndex = GetBucket(hashCode);
                        if (buckets[newBucketIndex] == null)
                        {
                            buckets[newBucketIndex] = new List<Entry>();
                        }
                        buckets[newBucketIndex].Add(entry);
                    }
                }
            }
        }
        public bool Remove(TKey key)
        {
            uint hashCode = (uint)key.GetHashCode();
            uint bucketIndex = GetBucket(hashCode);

            List<Entry> bucket = buckets[bucketIndex];
            if (bucket == null)
            {
                return false;
            }

            for (int i = 0; i < bucket.Count; i++)
            {
                if (bucket[i].Key.Equals(key))
                {
                    int lastIndex = bucket.Count - 1;
                    if (i != lastIndex)
                        bucket[i] = bucket[lastIndex];
                    bucket.RemoveAt(lastIndex);
                    Count--;
                    return true;
                }
            }
            return false;
        }

        public bool ContainsKey(TKey key)
        {
            uint hashCode = (uint)key.GetHashCode();
            uint bucketIndex = GetBucket(hashCode);
            if (buckets[bucketIndex] == null)
            {
                return false;
            }
            foreach (Entry entry in buckets[bucketIndex])
            {
                if (entry.Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsValue(TValue value)
        {
            foreach (List<Entry> bucket in buckets)
            {
                if (bucket != null)
                {
                    foreach (Entry entry in bucket)
                    {
                        if (entry.Value.Equals(value))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public TValue? TryGetValue(TKey key)
        {
            uint hashCode = (uint)key.GetHashCode();
            uint bucketIndex = GetBucket(hashCode);
            if (buckets[bucketIndex] == null)
            {
                return default;
            }

            foreach (Entry entry in buckets[bucketIndex])
            {
                if (entry.Key.Equals(key))
                {
                    return entry.Value;
                }
            }

            return default;
        }

        public void Clear()
        {
            Array.Clear(buckets);
            Count = 0;
        }

        private struct Entry
        {
            public TKey Key;
            public TValue Value;
        }

        private uint GetBucket(uint hashCode)
        {
            return (uint)(hashCode % buckets.Length);
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (List<Entry> bucket in buckets)
            {
                if (bucket != null)
                {
                    foreach (Entry entry in bucket)
                    {
                        yield return new KeyValuePair<TKey, TValue>(entry.Key, entry.Value);
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
