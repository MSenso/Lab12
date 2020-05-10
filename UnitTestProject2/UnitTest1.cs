using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab12_Generic_Collection;
using System.Collections;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void generic_collection()
        {
            OneList<Person> list = null;
            list = new OneList<Person>();
            int count = list.Count;
            list = new OneList<Person>(5);
            list.Clear();
            list = new OneList<Person>(new Person());
            count = list.Count;
            OneList<Person>.Clear(ref list);
            list = new OneList<Person>();
            list.Add(Program.Random_element());
            int size = 100;
            OneList<Person> default_list = new OneList<Person>(size);
            for (int i = 0; i < size; i++)
            {
                default_list.Add(Program.Random_element());
            }
            list = new OneList<Person>(default_list);
            list.Add(Program.Random_element(), Program.Random_element(), Program.Random_element());
            default_list = new OneList<Person>(8);
            default_list.Add(new Person("Иванов", 20));
            default_list.Add(new Person("Иванов", 21));
            default_list.Add(new Person("Иванов", 22));
            default_list.Add(new Person("Иванов", 23));
            default_list.Add(new Person("Иванов", 24));
            default_list.Add(new Person("Иванов", 25));
            default_list.Add(new Person("Иванов", 26));
            default_list.Remove(new Person("Иванов", 20), new Person("Иванов", 22), new Person("Иванов", 24), new Person("Иванов", 25), new Person("Иванов", 26));
            list = default_list.Clone();
            OneList<Person> temp_list = default_list.Shallow_Copy();
            default_list.Clear();
            OneList<Person>.Clear(ref default_list);
            list.Contains(new Person("Иванов", 21));
            list.Contains(new Person("Иванов", 22));
            list.Contains(null);
            Person[] people = new Person[list.Count];
            list.CopyTo(people, 0);
            list.Equals(null);
            default_list = new OneList<Person>();
            default_list.Add(new Person("Иванов", 26));
            default_list.Remove(new Person("Иванов", 26));
            list.Remove(new Person("Иванова", 20));
            bool read_only = list.IsReadOnly;
            list.Show();
            list.ToString();
            bool a = list != null;
            default_list = null;
            a = default_list != null;
            Person person = new Person();
            a = default_list != person;
            a = default_list == null;
            a = default_list == person;
            Queue queue = new Queue();
            list.Equals((object)person);
            list.Equals((object)queue);
            list.Equals((object)null);
            list.Search(person);
            list = new OneList<Person>();
            list.Add(new Person("Иванов", 20));
            list.Add(new Person("Иванов", 21));
            list.Search(new Person("Иванов", 21));
            list.GetEnumerator();
            object obj = list.GetEnumerator().Current;
            list.GetHashCode();
        }
    }
}
