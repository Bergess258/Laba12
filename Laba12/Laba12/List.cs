using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba12
{
    class List<T> : IEnumerable<T>, ICloneable, ICollection<T>, IComparer<T>
    {
        private int count = 0;
        private T[] mas = new T[0];
        public List()
        {

        }
        public List(int cap)
        {
            mas = new T[cap];
        }
        public List(T[] mas)
        {
            this.mas = mas;
        }

        public T this[int index]
        {
            get { return mas[index]; }
            set { mas[index] = value; }
        }
        static void RandAdd(int CountAdding)
        {
            do
            {
                Random rand = new Random();
                string Name = "";
                int c = rand.Next(4);
                if (c == 0)
                {
                    Region temp;
                    do
                    {
                        Name = RandomNameRegion(rand);
                        temp = new Region(Name, rand.Next(0, 10000000), rand.Next(0, 20));
                    } while (Contains(temp));
                    Add(temp);
                }
                else
                if (c == 1)
                {
                    City temp;
                    do
                    {
                        Name = RandomCity(rand);
                        temp = new City(Name, rand.Next(0, 900000));
                    } while (Contains(temp));
                    Places.Add(temp);
                }
                else
                if (c == 2)
                {
                    Megapolis temp;
                    do
                    {
                        Name = RandomMegapolis(rand);
                        temp = new Megapolis(Name, rand.Next(0, 20));
                    } while (Contains(temp));
                    Places.Add(temp);
                }
                else
                {
                    Adres temp;
                    do
                    {
                        Name = RandomAdres(rand);
                        temp = new Adres(Name);
                    } while (Contains(temp));
                    Add(temp);
                }
            } while (CountAdding-- > 0);
        }
        public void Add(T item)
        {
            if (count == mas.Length)
            {
                T[] Temp = new T[mas.Length + 1];
                mas.CopyTo(Temp, 0);
                Temp[Temp.Length - 1] = item;
                mas = Temp;
            }
            else
                mas[count] = item;
            count++;
        }
        public void Clear()
        {
            mas = new T[0];
        }
        public void CopyTo(T[] array, int index)
        {
            if (index > 0 && index <= mas.Length)
            {
                T[] Temp = new T[mas.Length - index + 1];
                int c = 0;
                for (int i = index - 1; i < mas.Length; i++)
                    Temp[c++] = mas[i];
                array = Temp;
            }
            else
                throw new IndexOutOfRangeException();
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public int Count
        {
            get { return count; }
        }
        public bool Remove(T item)
        {
            if (mas.Contains(item))
            {
                T[] Temp = new T[mas.Length - 1];
                int c = 0, c1 = -1;
                foreach (T temp in mas)
                {
                    c1++;
                    if (!temp.Equals(item)) Temp[c++] = mas[c1];
                }
                count--;
                return true;
            }
            return false;
        }
        public void Show()
        {
            foreach(T temp in mas)
            {
                Console.WriteLine(temp.ToString());
            }
        }
        public bool Contains(T Search)
        {
            foreach(T temp in mas)
            {
                if (temp.ToString()==Search.ToString()) return true;
            }
            return false;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)mas).GetEnumerator();//вапрыва
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<T>).GetEnumerator();
        }

        object ICloneable.Clone()
        {
            return this;
        }
        public void Sort()
        {
            Array.Sort(mas);
        }

        public int Compare(T x, T y)
        {
            if (x.ToString().Length == y.ToString().Length) return 0;
            if (x.ToString().Length > y.ToString().Length) return 1;
            return -1;
        }
    }
}
