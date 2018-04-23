using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba12
{
    class Collection : IEnumerable
    {
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
        public void CopyTo(PlacesV[] array, int index)
        {
            mas.CopyTo(array, index);
        }
        public bool IsReadOnly
        {
            get { return false; }
        }
        public int Count
        {
            get { return mas.Length; }
        }
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

        }
        public Collection Clone()
        {
            return null;
        }
        public void Sort()
        {

        }
        public void Search()
        {

        }
        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)mas).GetEnumerator();//вапрыва
        }
    }
}
