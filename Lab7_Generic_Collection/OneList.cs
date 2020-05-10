using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Lab12_Generic_Collection
{
    public class OneList<T>: IEnumerable<T>, ICollection<T>, IEquatable<T>
    {
        public T point;
        public  OneList<T> start;
        OneList<T> end;
        public OneList<T> next;
        private T[] items_array;
        private int size;
        public int Count { get { return size; } }
        int Capacity { get; set; }
        public OneList()
        {
            Capacity = 1;
            items_array = new T[Capacity];
            start = null;
            end = null;
            size = 0;
        }
        public OneList(int capacity)
        {
            try
            {
                items_array = new T[capacity];
                Capacity = capacity;
                start = null;
                end = null;
                next = null;
                size = 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public OneList(T point)
        {
            Capacity = 1;
            items_array = new T[Capacity];
            items_array[size] = point;
            this.point = point;
            start = null;
            end = this;
            next = null;
            size = 1;
        }
        public OneList(OneList<T> list)
        {
            try
            {
                items_array = new T[list.Capacity];
                Capacity = list.Capacity;
                OneList<T> list_for_copying = this;
                items_array = new T[list.Capacity];
                foreach (T point in list.items_array)
                {
                    if (point != null)
                    {
                        this.Add(point);
                    }

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Add(T point)
        {
            try
            {
                OneList<T> list = new OneList<T>(point);
                if (this.end == null)
                {
                    this.point = list.point;
                    this.end = this;
                }
                else
                {
                    this.end.next = list;
                    this.end = list;
                }
                if (size == this.Capacity)
                {
                    Capacity *= 2;
                    T[] new_items = new T[Capacity];
                    Array.Copy(items_array, new_items, size);
                    items_array = new_items;
                }
                items_array[size] = point;
                size++;
                this.start = new OneList<T>();
                this.start.next = this;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Add(params T[] points)
        {
            try
            {

                OneList<T> end_ref = null;
                for (int i = 0; i < points.Length; i++)
                {
                    this.Add(points[i]);
                    if (i == points.Length - 1) end_ref = this;
                }
                this.end = end_ref;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void Clear()
        {
            if (size > 0)
            {
                Array.Clear(items_array, 0, size);
                size = 0;
                start = null;
                end = null;
                Capacity = 1;
            }
        }
        public static void Clear(ref OneList<T> list)
        {
            list = null;
        }
        public bool Contains(T point)
        {
            try
            {
                foreach (T element in this)
                {
                    if (Compare_T_Objects(this.point, point))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public void CopyTo(T[] destination_array, int index)
        {
            Array.Copy(this.items_array, 0, destination_array, index, size);
        }
        public OneList<T> Shallow_Copy()
        {
            return (OneList<T>)this.MemberwiseClone();
        }
        public OneList<T> Clone()
        {
            return new OneList<T>(this);
        }
        public bool IsReadOnly { get; }
        public void Show()
        {
            foreach (T element in this)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine();
        }
        void Change_of_Capacity(T point)
        {
            if (size - 1 <= this.Capacity / 2) Capacity /= 2;
            T[] new_items = new T[Capacity];
            int j = 0;
            for (int i = 0; i < size; i++)
            {
                if (!Compare_T_Objects(items_array[i], point))
                {
                    new_items[j] = items_array[i];
                    j++;
                }
            }
            items_array = new_items;
            size--;
            this.start = new OneList<T>();
            this.start.next = this;
        }
        public bool Equals(T other)
        {
            if (other == null)
                return false;

            return Compare_T_Objects(this.point, other);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            try
            {
                if (!(obj is T personObj))
                    return false;
                else
                    return Equals(personObj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.point.GetHashCode();
        }

        static bool Compare_T_Objects(T obj1, T obj2)
        {
            MemoryStream memory_stream = new MemoryStream();
            BinaryFormatter binary_formatter = new BinaryFormatter();
            binary_formatter.Serialize(memory_stream, obj1);
            binary_formatter.Serialize(memory_stream, obj2);
            return Object.Equals(obj1, obj2);
        }
        public static bool operator ==(OneList<T> list, T point)
        {
            if (list == null)
            {
                if (point == null) return true;
                else return false;
            }
            return list.Equals(point);
        }

        public static bool operator !=(OneList<T> list, T point)
        {
            if (list == null)
            {
                if (point == null) return false;
                else return true;
            }
            return !(list.Equals(point));
        }
        public bool Remove(T point)
        {
                try
                {
                    OneList<T> temp = this;
                    if (this == point)
                    {
                        this.start.next = this.next;
                        if (this.next != null)
                        {
                            this.point = this.next.point;
                            this.next = this.next.next;
                        }
                        else
                        {
                            this.point = default(T);
                            this.next = null;
                            this.end = this.next;
                        }
                        Change_of_Capacity(point);
                        return true;
                    }
                    else
                    {
                        do
                        {
                            if (temp != null)
                            {
                                if (temp.next != null)
                                {
                                    if (temp.next == point)
                                    {
                                        if (temp.next.next != null)
                                        {
                                            temp.next = temp.next.next;
                                            Change_of_Capacity(point);
                                            return true;
                                        }
                                        else
                                        {
                                            temp.next = null;
                                            this.end = temp;
                                            Change_of_Capacity(point);
                                            return true;
                                        }
                                    }
                                }
                                temp = temp.next;
                            }
                        } while (temp != null);
                    }
                return true;
            }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        public bool Remove(params T[] points)
        {
            try
            {
                for(int i = 0; i < points.Length; i++)
                {
                    this.Remove(points[i]);
                }return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public T Search(T point)
        {
            try
            {
                foreach (T element in this)
                {
                    if (Compare_T_Objects(element, point))
                    {
                        return element;
                    }
                }
                return default(T);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return default(T);
            }
        }
        public override string ToString()
        {
            return point + " ";
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(this);
        }
    }
    class MyEnumerator<T>: IEnumerator<T>
    {
        OneList<T> start;
        OneList<T> current;
        public MyEnumerator(OneList<T> list)
        {
            start = list.start;
            current = list.start;
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
        public T Current
        {
            get { return current.point; }
        }
        public bool MoveNext()
        {
            if (current.next == null)
            {
                Reset();
                return false;
            }
            else
            {
                current = current.next;
                return true;
            }
        }
        public void Reset()
        {
            current = this.start;
        }
        public void Dispose() { }
    }
}
