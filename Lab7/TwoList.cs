using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class TwoList
    {
        public Person person;
        public TwoList next_person, previous_person;
        public TwoList()
        {
            person = null;
            next_person = null;
            previous_person = null;
        }
        public TwoList(Person this_person)
        {
            person = this_person;
            next_person = null;
            previous_person = null;
        }
    }
}
