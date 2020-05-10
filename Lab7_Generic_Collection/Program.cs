using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12_Generic_Collection
{
    public class Program
    {
        static int InputNumber(string ForUser, int left, int right)
        {
            bool ok;
            int number = 0;
            do
            {
                Console.WriteLine(ForUser);
                try
                {
                    string buf = Console.ReadLine();
                    number = Convert.ToInt32(buf);
                    if (number >= left && number <= right) ok = true;
                    else
                    {
                        Console.WriteLine("Неверный ввод числа!");
                        ok = false;
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Неверный ввод числа!");
                    ok = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный ввод числа!");
                    ok = false;
                }
            }
            while (!ok);
            return number;
        }
        public static Person Random_element()
        {
            int choice = random.Next(1, 5);
            Person element = null;
            switch (choice)
            {
                case 1:
                    {
                        element = new Person(names[random.Next(0, 12)], random.Next(18, 60));
                        break;
                    }
                case 2:
                    {
                        element = new Student(names[random.Next(0, 12)], random.Next(18, 25), random.Next(1, 5), random.Next(1, 5) + random.NextDouble());
                        break;
                    }
                case 3:
                    {
                        element = new Researcher(names[random.Next(0, 12)], random.Next(25, 60), posts[random.Next(0, 5)]);
                        break;
                    }
                case 4:
                    {
                        element = new Professor(names[random.Next(0, 12)], random.Next(25, 60), posts[random.Next(0, 5)], professor_posts[random.Next(0, 5)], departments[random.Next(0, 5)]);
                        break;
                    }
            }
            return element;
        }
        #region Данные
        static Random random = new Random();
        const int size = 100, changing_count = 5;
        #endregion
        #region Массивы данных
        static string[] names = { "Иванов", "Иванова", "Петров", "Петрова", "Сидоров", "Сидорова", "Кузнецов", "Кузнецова", "Соколов", "Соколова", "Галкин", "Галкина" };
        static string[] posts = { "младший научный сотрудник", "научный сотрудник", "старший научный сотрудник", "ведущий научный сотрудник", "главный научный сотрудник" };
        static string[] professor_posts = { "ассистент", "преподаватель", "старший преподаватель", "доцент", "профессор" };
        static string[] departments = { "кафедра высшей математики", "кафедра гражданского и предпринимательнского права", "кафедра гуманитарных дисциплин", "кафедра информационных технологий в бизнесе", "кафедра физического воспитания" };
        #endregion
        static void OneListMenu()
        {
            Console.WriteLine("1. Сформировать однонаправленный список");
            Console.WriteLine("2. Распечатать однонаправленный список");
            Console.WriteLine("3. Получить количество элементов в списке");
            Console.WriteLine("4. Добавить элемент в список");
            Console.WriteLine("5. Добавить элементы в список");
            Console.WriteLine("6. Удалить элемент из списка");
            Console.WriteLine("7. Удалить элементы из списка");
            Console.WriteLine("8. Найти элемент по значению");
            Console.WriteLine("9. Показать клон коллекции");
            Console.WriteLine("10. Показать копию коллекции");
            Console.WriteLine("11. Удалить коллекцию из памяти");
            Console.WriteLine("12. Выход");
        }
        static void Making_List_Menu()
        {
            Console.WriteLine("1. Создать пустую коллекцию");
            Console.WriteLine("2. Создать пустую коллекцию заданной емкости");
            Console.WriteLine("3. Создать коллекцию из элементов другой коллекции");
            Console.WriteLine("4. Выход");
        }
        static void Making_List(ref OneList<Person> list)
        {
            Making_List_Menu();
            int choice = InputNumber("", 1, 4);
            switch(choice)
            {
                case 1:
                    {
                        list = new OneList<Person>();
                        Console.WriteLine("Коллекция сформирована");
                        break;
                    }
                case 2:
                    {
                        int capacity = InputNumber("Введите емкость коллекции:", 1, int.MaxValue);
                        list = new OneList<Person>(capacity);
                        Console.WriteLine("Коллекция сформирована");
                        break;
                    }
                case 3:
                    {
                        OneList<Person> default_list = new OneList<Person>(size);
                        for(int i = 0; i < size; i++)
                        {
                            default_list.Add(Random_element());
                        }
                        Console.WriteLine("Коллекция для копирования: ");
                        default_list.Show();
                        list = new OneList<Person>(default_list);
                        Console.WriteLine("Коллекция сформирована");
                        break;
                    }
                default: break;
            }
        }
        public static Person Forming_Person()
        {
            bool is_correct = true;
            Person person = null;
            do
            {
                Console.WriteLine("Введите фамилию и возраст от 18 до 60 через пробел");
                string answer = Console.ReadLine();
                if (answer != string.Empty)
                {
                    string[] data = answer.Split(' ');
                    if (data.Length != 2)
                    {
                        Console.WriteLine("Некорректный ввод данных!");
                        is_correct = false;
                    }
                    else
                    {
                        int age = 0;
                        if (int.TryParse(data[1], out age))
                        {
                            if (age >= 18 && age <= 60)
                            {
                                if (data[0].Any(char.IsDigit))
                                {
                                    Console.WriteLine("Фамилия не может содержать цифры!");
                                    is_correct = false;
                                }
                                else
                                {
                                    string name = data[0];
                                    person = new Person(name, age);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Указанный возраст находится вне диапазона!");
                                is_correct = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод данных!");
                            is_correct = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка, пустая строка!");
                    is_correct = false;
                }

            } while (!is_correct);
            return person;
        }
        static void Run()
        {
            OneList<Person> list = null;
            OneList<Person> clone_list = null, copy_list = null;
            int choice = 0;
            do
            {
                OneListMenu();
                choice = InputNumber("", 1, 12);
                switch (choice)
                {
                    case 1:
                        {
                            Making_List(ref list);
                            break;
                        }
                    case 2:
                        {
                            if (list != null)
                            {
                                list.Show();
                            }
                            else Console.WriteLine("Коллекция пустая!");
                            break;
                        }
                    case 3:
                        {
                            if (list != null)
                            {
                                Console.WriteLine("Количество элементов в списке равно " + list.Count);
                            }
                            else Console.WriteLine("Коллекция пустая!");
                            break;
                        }
                    case 4:
                        {
                            if (list != null)
                            {
                                Person person = Random_element();
                                list.Add(person);
                                Console.WriteLine("Случайный элемент был добавлен");
                            }
                            else Console.WriteLine("Коллекция пустая!");
                            break;
                        }
                    case 5:
                        {
                            if (list != null)
                            {
                                int count = InputNumber("Введите количество добавляемых элементов", 1, int.MaxValue);
                                Person[] people = new Person[count];
                                for (int i = 0; i < count; i++)
                                {
                                    people[i] = Random_element();
                                }
                                list.Add(people);
                                Console.WriteLine("Случайные элементы были добавлены");
                            }
                            else Console.WriteLine("Коллекция пустая!");
                            break;
                        }
                    case 6:
                        {
                            if (list != null)
                            {
                                Person person = Forming_Person();
                                list.Remove(person);
                                Console.WriteLine("Указанный элемент был удален");
                            }
                            else Console.WriteLine("Коллекция пустая!");
                            break;
                        }
                    case 7:
                        {
                            if (list != null)
                            {
                                int count = InputNumber("Укажите количество удаляемых элементов, не менее 1 и не более размера коллекции", 1, list.Count);
                                Person[] people = new Person[count];
                                for (int i = 0; i < count; i++)
                                {
                                    people[i] = Forming_Person();
                                }
                                list.Remove(people);
                                Console.WriteLine("Указанные элементы были удалены");
                            }
                            else Console.WriteLine("Коллекция пустая!");
                            break;
                        }
                    case 8:
                        {
                            if (list != null)
                            {
                                Person person = Forming_Person();
                                Person found_person = list.Search(person);
                                if (found_person != null)
                                {
                                    Console.WriteLine("Найденный элемент: ");
                                    found_person.Show();
                                }
                                else Console.WriteLine("Элемент не найден!");
                            }
                            else Console.WriteLine("Коллекция пустая!");
                            break;

                        }
                    case 9:
                        {
                            if (list != null)
                            {
                                if (clone_list == null) clone_list = list.Clone();
                                Console.WriteLine("Коллекция-клон: ");
                                clone_list.Show();
                            }
                            else Console.WriteLine("Коллекция пустая!");
                            break;
                        }
                    case 10:
                        {
                            if (list != null)
                            {
                                if (copy_list == null) copy_list = list.Shallow_Copy();
                                Console.WriteLine("Коллекция-копия: ");
                                copy_list.Show();
                            }
                            else Console.WriteLine("Коллекция пустая!");
                            break;
                        }
                    case 11:
                        {
                            if (list != null)
                            {
                                OneList<Person>.Clear(ref list);
                                Console.WriteLine("Коллекция удалена из памяти");
                            }
                            else Console.WriteLine("Коллекция пустая!");
                            break;
                        }
                    default: break;
                }
            } while (choice < 12);
        }
        static void Main(string[] args)
        {
            Run();
        }
    }
}
