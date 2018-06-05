using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba12
{
    class List<T> : IEnumerable<T>, ICloneable, ICollection<T>,IEnumerator<T>
    {
        int position = -1;
        private int count = 0;
        private T[] mas = new T[8];
        public List()
        {

        }
        public List(int cap)
        {
            mas = new T[cap];
        }
        public List(T[] mas)
        {
            int c = 0;
            foreach (T t in mas)
                this.mas[c++] = t;
            
        }
        public T this[int index]
        {
            get { return mas[index]; }
            set { mas[index] = value; }
        }
        public void Add(T item)
        {
            mas[count++] = item;
            if (count == mas.Length)
            {
                T[] temp = new T[mas.Length + 12];
                mas.CopyTo(temp, 0);
                mas = temp;
            }
        }
        public void Clear()
        {
            mas = new T[0];
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
            foreach (T temp in mas)
            {
                Console.WriteLine(temp.ToString());
            }
        }
        public bool Contains(T Search)
        {
            foreach (T temp in mas)
            {
                if (temp.ToString() == Search.ToString()) return true;
            }
            return false;
        }
        public bool Contains(PlacesV Search)
        {
            foreach (T temp in mas)
            {
                if (temp.ToString() == Search.ToString()) return true;
            }
            return false;
        }
        public T Current
        {
            get { return mas[position]; }
        }
        object IEnumerator.Current { get { return mas[position]; } } 
        object ICloneable.Clone()
        {
            return this;
        }
        public void Sort()
        {
            Array.Sort(mas);
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
        public void Dispose()
        {
            ((IEnumerator)this).Reset();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)this;
        }
        public bool MoveNext()
        {
            if (position < count - 1)
            {
                position++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            position = -1;
        }
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }
    }
}
