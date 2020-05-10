using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class OneList
    {
        public Person person;
        public OneList next_person;
        public OneList()
        {
            person = null;
            next_person = null;
        }
        public OneList(Person this_person)
        {
            person = this_person;
            next_person = null;
        }
    }
}
