using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class SortByName : IComparer<object>
    {
        public int Compare(object ob1, object ob2)
        {
            Person person_1 = (Person)ob1;
            Person person_2 = (Person)ob2;
            int result = String.Compare(person_1.Name, person_2.Name);
            if (result == 0)
            {
                if (person_1.Age < person_2.Age) result = -1;
                else if (person_1.Age > person_2.Age) result = 1;
            }
            return result;
        }
    }

}
