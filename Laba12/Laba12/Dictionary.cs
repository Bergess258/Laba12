using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba12
{
    class Entry
    {
        public int HashCode =-1;
        public int Next=-1;
        public PlacesV Value;
        public PlacesV Key;
    }
    class Dictionary : IDictionary<object, object>
    {
        private int count;
        private int SizeMass;
        private int[] buckets;
        private Entry[] entries;
        public object this[object key]
        {
            get
            {
                int place = buckets[GetHash(key)];
                Entry temp = entries[place];
                if (temp.HashCode != -1)
                {
                    do
                    {
                        if (temp.Key.ToString() == key.ToString()) return temp;
                        else
                        {
                            if (temp.Next == -1)
                            {
                                throw new Exception("Такого элемента нет");
                            }
                            temp = entries[temp.Next];
                        }
                    } while (true);
                }
                throw new Exception("Такого элемента нет");
            }
            set
            {
                int hash = GetHash(key);
                int place = buckets[hash];
                Entry temp = entries[place];
                if (temp.HashCode != -1)
                {
                    do
                    {
                        if (temp.Key.ToString() == key.ToString() &&temp.Value.ToString()==value.ToString()) break;
                        else
                        {
                            if (temp.Next == -1)
                            {
                                temp.Next = count;
                                Entry Temp2=new Entry();
                                Temp2.HashCode = hash;
                                Temp2.Key = (PlacesV)key;
                                Temp2.Value = (PlacesV)value;
                                entries[count] = Temp2;
                            }
                        }
                    } while (true);
                }
                else
                {
                    temp.Value = (PlacesV)value;//проверить
                    temp.Key = (PlacesV)key;
                    entries[place] = temp;
                }
            }
        }

        public int[] Keys => throw new NotImplementedException();

        public Entry[] Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        ICollection<object> IDictionary<object, object>.Keys => throw new NotImplementedException();

        ICollection<object> IDictionary<object, object>.Values => throw new NotImplementedException();
        public void Add(object key, object value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<object, object> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
        public bool Contains(KeyValuePair<object, object> item)
        {
            throw new NotImplementedException();
        }
        public bool ContainsKey(object key)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(KeyValuePair<object, object>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public int GetHash(object adres)
        {
            int hashcode = 0;
            double a = 0.6180339887;
            foreach (char s in adres.ToString()) hashcode += (int)s;
            var p = Math.Truncate(hashcode * a);
            var t = hashcode * a - p;
            hashcode = (int)(SizeMass * t) % SizeMass;
            return hashcode;
        }
        public bool Remove(object key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<object, object> item)
        {
            throw new NotImplementedException();
        }
        public bool TryGetValue(object key, out object value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<KeyValuePair<object, object>> IEnumerable<KeyValuePair<object, object>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
