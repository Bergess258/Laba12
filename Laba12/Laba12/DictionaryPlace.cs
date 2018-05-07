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
        public override string ToString()
        {
            return Key.ToString() + "   " + Value.ToString();
        }
    }
    class DictionaryPlace : IDictionary<PlacesV, PlacesV>
    {
        private int count=0;
        private int SizeMass=100;
        private int[] buckets=new int[100];
        private Entry[] entries=new Entry[100];
        public DictionaryPlace()
        {
            for (int i = 0; i < SizeMass; i++)
            {
                buckets[i] = -1;
            }
            Point temp = new Point();
            for (int i = 0; i < SizeMass; i++)
            {
                entries[i] = new Entry();
            }
        }
        public PlacesV this[PlacesV key]
        {
            get
            {
                int place = buckets[GetHash(key)];
                Entry temp = entries[place];
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
                            temp = entries[temp.Next];
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
        public int Count
        {
            get { return count; }
        }

        public bool IsReadOnly { get { return false; } }

        ICollection<PlacesV> IDictionary<PlacesV, PlacesV>.Keys
        {
            get
            {
                PlacesV[] Temp = new PlacesV[count];
                for(int i = 0; i < count; i++)
                {
                    Temp[i] = entries[i].Key;
                }
                return Temp;
            }
        }

        ICollection<PlacesV> IDictionary<PlacesV, PlacesV>.Values => throw new NotImplementedException();
        public void Add(PlacesV key, PlacesV value)
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
                Entry[] Temp;
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
            if (SizeMass - 100 != 0)
                if ((count / (double)(SizeMass - 100)) < 0.1)
                {
                    SizeMass -= 100;
                    int[] te;
                    Entry[] Temp;
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

        private void CreateMasses(out int[] te, out Entry[] Temp)
        {
            te = new int[SizeMass];
            Temp = new Entry[SizeMass];
            for (int i = 0; i < SizeMass; i++)
            {
                te[i] = -1;
            }
            for (int i = 0; i < SizeMass; i++)
            {
                Temp[i] = new Entry();
            }
        }

        public void Add(KeyValuePair<PlacesV, PlacesV> item)
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
            entries = new Entry[100];
        }
        public bool Contains(KeyValuePair<PlacesV, PlacesV> item)
        {
            throw new NotImplementedException();
        }
        public bool ContainsKey(PlacesV key)
        {
            throw new NotImplementedException();
        }
        public void CopyTo(KeyValuePair<PlacesV, PlacesV>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public int GetHash(PlacesV adres)
        {
            int hashcode = 0;
            double a = 0.6180339887;
            foreach (char s in adres.ToString()) hashcode += (int)s;
            var p = Math.Truncate(hashcode * a);
            var t = hashcode * a - p;
            hashcode = (int)(SizeMass * t) % SizeMass;
            return hashcode;
        }
        public bool Remove(PlacesV key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<PlacesV, PlacesV> item)
        {
            throw new NotImplementedException();
        }
        public bool TryGetValue(PlacesV key, out PlacesV value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<KeyValuePair<PlacesV, PlacesV>> IEnumerable<KeyValuePair<PlacesV, PlacesV>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public void Show()
        {
            foreach (Entry temp in entries)
            {
                Console.WriteLine(temp);
            }
        }
    }
}
