using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class Tree
    {
        public Person person;
        public Tree left, right;
        public Tree()
        {
            person = null;
            left = null;
            right = null;
        }
        public Tree(Person this_person)
        {
            person = this_person;
            left = null;
            right = null;
        }
    }
}
