using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba12
{
    class Point
    {
        public int HashCode = -1;
        public int Next = -1;
        public object Value;
        public object Key;
    }
    class DictionaryCommon : IDictionary<object, object>,IDisposable
    {
        private int count=0;
        private int SizeMass=100;
        private int[] buckets=new int[100];
        private Point[] entries= new Point[100];
        public object this[object key]
        {
            get
            {
                int place = buckets[GetHash(key)];
                Point temp = entries[place];
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
                Point temp = entries[place];
                if (temp.HashCode != -1)
                {
                    do
                    {
                        if (temp.Key.ToString() == key.ToString() && temp.Value.ToString() == value.ToString()) break;
                        else
                        {
                            if (temp.Next == -1)
                            {
                                temp.Next = count;
                                Point Temp2 = new Point();
                                Temp2.HashCode = hash;
                                Temp2.Key = key;
                                Temp2.Value = value;
                                entries[count] = Temp2;
                                break;
                            }
                            temp = entries[temp.Next];
                        }
                    } while (true);
                }
                else
                {
                    temp.Value = value;//проверить
                    temp.Key = key;
                    entries[place] = temp;
                }
            }
        }
        public int Count
        {
            get { return count; }
        }

        public bool IsReadOnly { get { return false; } }

        ICollection<object> IDictionary<object, object>.Keys
        {
            get
            {
                object[] Temp = new object[count];
                for (int i = 0; i < count; i++)
                {
                    Temp[i] = entries[i].Key;
                }
                return Temp;
            }
        }
        ICollection<object> IDictionary<object, object>.Values
        {
            get
            {
                object[] Temp = new object[count];
                for (int i = 0; i < count; i++)
                {
                    Temp[i] = entries[i].Value;
                }
                return Temp;
            }
        }
        public void Add(object key, object value)
        {
            int hash = GetHash(key);
            buckets[hash] = count;
            this[hash] = value;
            count++;
            CheckForSize();
        }

        private void CheckForSize()
        {
            if (SizeMass / count > 0.7)
            {
                SizeMass += 100;
                int[] te = new int[SizeMass];
                Point[] Temp = new Point[SizeMass];
                for (int i = 0; i < count; i++)
                {
                    Temp[i] = entries[i];
                    te[GetHash(entries[i].Key)] = i;
                }
                entries = Temp;
                buckets = te;
            }
            else
                if (SizeMass / count < 0.1 && SizeMass / count != 0)
                {
                    SizeMass -= 100;
                    int[] te = new int[SizeMass];
                    Point[] Temp = new Point[SizeMass];
                    for (int i = 0; i < count; i++)
                    {
                        Temp[i] = entries[i];
                        te[GetHash(entries[i].Key)] = i;
                    }
                    entries = Temp;
                    buckets = te;
                }
        }

        public void Add(KeyValuePair<object, object> item)
        {
            int hash = GetHash(item.Key);
            buckets[hash] = count;
            this[hash] = item.Value;
            count++;
            CheckForSize();
        }

        public void Clear()
        {
            count = 0;
            SizeMass = 100;
            buckets = new int[100];
            entries = new Point[100];
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

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)buckets).GetEnumerator();
        }

        public int GetHash(object adres)
        {
            int hashcode = 0;
            double a = 0.6180339887;
            foreach (char s in adres.ToString()) hashcode += (int)s;
            var p = Math.Truncate(hashcode * a);
            var t = (hashcode * a - p)%SizeMass;
            return (int)t;
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
        IEnumerator<KeyValuePair<object, object>> IEnumerable<KeyValuePair<object, object>>.GetEnumerator()
        {
            return (this as IEnumerable<KeyValuePair<object, object>>).GetEnumerator();
        }

        public void Dispose()
        {
            Clear();
        }
    }
}
