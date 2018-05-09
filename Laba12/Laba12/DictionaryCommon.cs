using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba12
{
    class Point: IComparable
    {
        public int HashCode = -1;
        public int Next = -1;
        public object Value;
        public object Key;
        public Point()
        {
            Value = "";
            Key = "";
        }

        public int CompareTo(object x)
        {
            if (x.ToString() == this.ToString()) return 0;
            if (x.ToString().Length > this.ToString().Length) return 1;
            return -1;
        }

        public override string ToString()
        {
            return Key.ToString()+"   "+Value.ToString();
        }
    }
    class DictionaryCommon : IDictionary<object, object>,IDisposable, ICloneable,IEnumerator
    {
        private int count=0;
        private int position = 0;
        private int SizeMass=100;
        private int[] buckets=new int[100];
        private Point[] entries= new Point[100];
        public DictionaryCommon()
        {
            for(int i = 0; i < SizeMass; i++)
            {
                buckets[i] = -1;
            }
            Point temp = new Point();
            for (int i = 0; i < SizeMass; i++)
            {
                entries[i] = new Point();
            }
        }
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
                        if (temp.Key.ToString() == key.ToString()) return temp.Value;
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
                                entries[count] = new Point() { HashCode = hash, Key = key, Value = value, Next=count};
                                break;
                            }
                            temp = entries[temp.Next];
                        }
                    } while (true);
                }
                else
                {
                    entries[place] = new Point() { HashCode = hash, Key = key, Value = value };
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
        public void Show()
        {
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine(entries[i].ToString());
            }
        }
        public void Sort()
        {
            ClearBuckets();
            Array.Sort(entries);
            for(int i = 0; i < count; i++)
            {
                int hash = entries[i].HashCode;
                if (buckets[hash] == -1) buckets[hash] = i;
                else
                {
                    Point temp = entries[buckets[hash]];
                    do
                    {
                        if (temp.Next == -1) { temp.Next = i;break; }
                        temp = entries[temp.Next];
                    } while (true);
                }
                    
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
            buckets[hash] = count++;
            this[key] = value;
            CheckForSize();
        }

        private void CheckForSize()
        {
            if (count / (double)SizeMass > 0.7)
            {
                SizeMass += 100;
                int[] te;
                Point[] Temp;
                CreateMasses(out te, out Temp);
                for (int i = 0; i < count; i++)
                {
                    Temp[i] = entries[i];
                    te[GetHash(entries[i].Key)] = i;
                }
                entries = Temp;
                buckets = te;
            }
            else
            if(SizeMass-100!=0)
                if ((count/(double)(SizeMass-100)) < 0.1)
                {
                    SizeMass -= 100;
                    int[] te;
                    Point[] Temp;
                    CreateMasses(out te, out Temp);
                    for (int i = 0; i < count; i++)
                    {
                        Temp[i] = entries[i];
                        te[GetHash(entries[i].Key)] = i;
                    }
                    entries = Temp;
                    buckets = te;
                }
        }

        private void CreateMasses(out int[] te, out Point[] Temp)
        {
            te = new int[SizeMass];
            Temp = new Point[SizeMass];
            for (int i = 0; i < SizeMass; i++)
            {
                te[i] = -1;
            }
            for (int i = 0; i < SizeMass; i++)
            {
                Temp[i] = new Point();
            }
        }

        public void Add(KeyValuePair<object, object> item)
        {
            int hash = GetHash(item.Key);
            buckets[hash] = count++;
            this[item.Key] = item.Value;
            CheckForSize();
        }

        public void Clear()
        {
            count = 0;
            SizeMass = 100;
            buckets = new int[100];
            entries = new Point[100];
            ClearBuckets();
            ClearEntries();
        }

        private void ClearEntries()
        {
            for (int i = 0; i < SizeMass; i++)
            {
                entries[i] = new Point();
            }
        }

        private void ClearBuckets()
        {
            for (int i = 0; i < SizeMass; i++)
            {
                buckets[i] = -1;
            }
        }

        public bool Contains(KeyValuePair<object, object> item)
        {
            int hash = GetHash(item.Key);
            int place = buckets[hash];
            Point temp = entries[place];
            if (place == -1) return false;
            do
            {
                if (temp.Key == item.Key && temp.Value == item.Value) return true;
                if (temp.Next == -1) return false;
                temp = entries[temp.Next];
            } while (true);
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
        bool IEnumerator.MoveNext()
        {
            if (position++ < count) return true;
            return false;
        }
        object IEnumerator.Current
        {
            get { return entries[position]; }
        }
        void IEnumerator.Reset()
        {
            position = 0;
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
            int hash = GetHash(key);
            int place = buckets[hash];
            Point Temp = entries[place];
            do
            {
                if (Temp.Key == key)
                {
                    for (int i = place + 1; i < count; i++)
                    {
                        entries[i - 1] = entries[i];
                        buckets[entries[i].HashCode]--;
                    }
                    return true;
                }
                if (Temp.Next == -1) return false;
                else Temp = entries[Temp.Next];
            } while (true);
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

        public object Clone()
        {
            Point[] Temp = new Point[SizeMass];
            for (int i = 0; i < SizeMass; i++)
                Temp[i] = entries[i];
            return new DictionaryCommon
            {
                count = this.count,
                buckets = this.buckets,
                entries = Temp,
                SizeMass=this.SizeMass
            };
        }
    }
}
