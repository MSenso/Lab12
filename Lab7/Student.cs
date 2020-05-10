using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    [Serializable]
    class Student : Person, IExecutable, ICloneable
    {
        protected int course;
        protected double rating;
        public int Course
        {
            set { if (value <= 5 && value >= 1) course = value; else course = 1; }
            get { return course; }
        }
        public double Rating
        {
            set { if (value <= 5 && value >= 0) rating = value; else rating = 0; }
            get { return rating; }
        }
        public Student()
            : base()
        {
            rating = 0.0;
            course = 1;
        }
        public Student(string name, int age, int course, double rating)
            : base(name, age)
        {
            this.Rating = rating;
            this.Course = course;
        }
        public override void Init()
        {
            base.Init();
            Console.WriteLine("Введите курс");
            Course = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("введите рейтинг");
            Rating = Convert.ToDouble(Console.ReadLine());
        }
        public override string ToString()
        {
            return base.ToString() + ", курс: " + course + ", рейтинг: " + String.Format("{0:F2}", rating);
        }
        public override void Show()
        {

            Console.WriteLine(this.ToString());
        }
        public override object Clone()
        {
            Person temp_person = (Person)base.Clone();
            Student temp_student = new Student(temp_person.Name, temp_person.Age, this.Course, this.Rating);
            return temp_student;
        }
    }

}
