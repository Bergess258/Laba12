using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Collection<T> : IEnumerable
{
    T[] mas = new T[0];
    public T this[int index]
    {
        get { return mas[index]; }
        set { mas[index] = value; }
    }
    public void Add(T item)
    {
        T[] Temp = new T[mas.Length + 1];
        mas.CopyTo(Temp, 0);
        Temp[Temp.Length - 1] = item;
        mas = Temp;
    }
    public void Clear()
    {
        mas = new T[0];
    }
    public void CopyTo(T[] array, int index)
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
            return true;
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
}
