using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba12
{
    class ArrayList : IEnumerable, ICloneable, ICollection, IComparer, IEnumerator
    {
        int position = 0;
        PlacesV[] mas = new PlacesV[0];
        public PlacesV this[int index]
        {
            get { return mas[index]; }
            set { mas[index] = value; }
        }
        public void Add(PlacesV item)
        {
            PlacesV[] Temp = new PlacesV[mas.Length + 1];
            mas.CopyTo(Temp, 0);
            Temp[Temp.Length - 1] = item;
            mas = Temp;
        }
        public void Clear()
        {
            mas = new PlacesV[0];
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public int Count
        {
            get { return mas.Length; }
        }

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized { get { return false; } }

        public bool IsFixedSize { get { return false; } }

        object IList.this[int index] { get { return mas[index]; } set { mas[index]=(PlacesV)value; } }

        public bool Remove(PlacesV item)
        {
            if (mas.Contains(item))
            {
                PlacesV[] Temp = new PlacesV[mas.Length - 1];
                int c = 0, c1 = -1;
                foreach (PlacesV temp in mas)
                {
                    c1++;
                    if (!temp.Equals(item)) Temp[c++] = mas[c1];
                }
                return true;
            }
            return false;
        }
        public void Show()
        {
            foreach (PlacesV temp in mas)
            {
                Console.WriteLine(temp.ToString());
            }
        }
        public bool Contains(PlacesV Search)
        {
            foreach (PlacesV temp in mas)
            {
                if (temp.ToString() == Search.ToString()) return true;
            }
            return false;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
        bool IEnumerator.MoveNext()
        {
            if (position++ < mas.Length) return true;
            return false;
        }
        object IEnumerator.Current
        {
            get { return mas[position]; }
        }
        void IEnumerator.Reset()
        {
            position = 0;
        }
        object ICloneable.Clone()
        {
            return this;
        }
        public void Sort()
        {
            Array.Sort(mas);
        }
        public int Compare(object x, object y)
        {
            if (x.ToString().Length == y.ToString().Length) return 0;
            if (x.ToString().Length > y.ToString().Length) return 1;
            return -1;
        }

        public void CopyTo(Array array, int index)
        {
            if (index > 0 && index <= mas.Length)
            {
                PlacesV[] Temp = new PlacesV[mas.Length - index + 1];
                int c = 0;
                for (int i = index - 1; i < mas.Length; i++)
                    Temp[c++] = mas[i];
                array = Temp;
            }
            else
                throw new IndexOutOfRangeException();
        }
        public void RemoveAt(int index)
        {
            
        }
    }
}
