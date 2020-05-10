using System;
namespace Lab12
{
    public class Program
    {
        #region Данные
        public const double double_min = 0.0, double_max = 10.0;
        public const int size = 20;
        public static Random random = new Random();
        #endregion
        #region Массивы данных
        public static string[] names = { "Иванов", "Иванова", "Петров", "Петрова", "Сидоров", "Сидорова", "Кузнецов", "Кузнецова", "Соколов", "Соколова", "Галкин", "Галкина" };
        public static string[] posts = { "младший научный сотрудник", "научный сотрудник", "старший научный сотрудник", "ведущий научный сотрудник", "главный научный сотрудник" };
        public static string[] professor_posts = { "ассистент", "преподаватель", "старший преподаватель", "доцент", "профессор" };
        public static string[] departments = { "кафедра высшей математики", "кафедра гражданского и предпринимательнского права", "кафедра гуманитарных дисциплин", "кафедра информационных технологий в бизнесе", "кафедра физического воспитания" };
        #endregion

        #region Ввод
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
        static int InputNumber(string ForUser, int left)
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
                    if (number >= left) ok = true;
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
        static Person Random_element()
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
        #endregion
        static void MainMenu()
        {
            Console.WriteLine("1. Работа с однонаправленными списками");
            Console.WriteLine("2. Работа с двунаправленными списками");
            Console.WriteLine("3. Работа с бинарными деревьями");
            Console.WriteLine("4. Выход");
        }
        static void Run()
        {
            int choice = 0;
            do
            {
                MainMenu();
                choice = InputNumber("", 1, 4);
                switch (choice)
                {
                    case 1:
                        OneListMainMenu();
                        break;
                    case 2:
                        TwoListMainMenu();
                        break;
                    case 3:
                        TreeMainMenu();
                        break;
                }
            } while (choice < 4);
        }
        #region OneList
        public static OneList Make_One_List_Person(Person this_person)
        {
            OneList person = new OneList(this_person);
            return person;
        }
        public static OneList MakeOneList()
        {
            OneList start = Make_One_List_Person(new Person("Иванов", 20));
            OneList current_point = start;
            for (int i = 1; i < size; i++)
            {
                OneList new_point = Make_One_List_Person(Random_element());
                current_point.next_person = new_point;
                current_point = new_point;
            }
            Console.WriteLine("Список сформирован");
            return start;
        }
        public static void ShowList(OneList start)
        {
            if (start == null)
            {
                Console.WriteLine("Список пустой!");
                return;
            }
            OneList current_point = start;
            while (current_point != null)
            {
                Console.WriteLine(current_point);
                current_point = current_point.next_person;
            }
            Console.WriteLine();
        }
        public static OneList Delete_Element(OneList start)
        {
            if (start == null)
            {
                Console.WriteLine("Список пустой!");
                return null;
            }
            if (start.person == null)
            {
                Console.WriteLine("В списке нет элементов!");
                return start;
            }
            do
            {
                if (start.person.Age % 2 == 0)
                    start = start.next_person;
            } while (start.person.Age % 2 == 0);
            OneList current_point = start;
            OneList last_odd_point = start;
            for (int i = 0; current_point != null; i++)
            {
                if (current_point.person.Age % 2 == 0)
                {
                    if (current_point.next_person != null)
                    {
                        if (current_point.next_person.person.Age % 2 != 0)
                        {
                            last_odd_point.next_person = current_point.next_person;
                            last_odd_point = last_odd_point.next_person;
                        }
                    }
                    else
                    {
                        last_odd_point.next_person = null;
                        last_odd_point = last_odd_point.next_person;
                    }
                }
                else
                {
                    last_odd_point = current_point;
                }
                current_point = current_point.next_person;
            }
            Console.WriteLine("Элементы удалены");
            return start;
        }
        public static OneList Delete(OneList start)
        {
            if (start == null) Console.WriteLine("Список пустой!");
            else
            {
                start = null;
                Console.WriteLine("Список удален");
            }
            return start;
        }
        static void OneListMenu()
        {
            Console.WriteLine("1. Сформировать однонаправленный список");
            Console.WriteLine("2. Распечатать однонаправленный список");
            Console.WriteLine("3. Удаление элементов с четным инфромационным полем");
            Console.WriteLine("4. Удаление списка из памяти");
            Console.WriteLine("5. Выход");
        }
        static void OneListMainMenu()
        {
            OneList start = null;
            int choice = 0;
            do
            {
                OneListMenu();
                choice = InputNumber("", 1, 5);
                switch (choice)
                {
                    case 1:
                        start = MakeOneList();
                        break;
                    case 2:
                        ShowList(start);
                        break;
                    case 3:
                        start = Delete_Element(start);
                        break;
                    case 4:
                        start = Delete(start);
                        break;
                }
            } while (choice < 5);
        }
        #endregion
        #region TwoList
        public static TwoList Make_Two_List_Person(Person this_person)
        {
            TwoList person = new TwoList(this_person);
            return person;
        }
        public static TwoList MakeTwoList()
        {
            TwoList start = null;
            start = Make_Two_List_Person(Random_element());
            TwoList current_point = start;
            for (int i = 1; i < size; i++)
            {
                TwoList new_person = Make_Two_List_Person(Random_element());
                current_point.next_person = new_person;
                new_person.previous_person = current_point;
                current_point = new_person;
            }
            Console.WriteLine("Список сформирован");
            return start;
        }
        public static void ShowList(TwoList start)
        {
            if (start == null)
            {
                Console.WriteLine("Список пустой!");
                return;
            }
            TwoList current_point = start;
            while (current_point != null)
            {
                Console.WriteLine(current_point);
                current_point = current_point.next_person;
            }
            Console.WriteLine();
        }
        public static TwoList AddPoint(TwoList start, int number, Random rand)
        {
            TwoList new_point = Make_Two_List_Person(Random_element());
            if (start == null)
            {
                Console.WriteLine("В списке нет элементов, поэтому добавляемый элемент имеет номер 1");
                start = new_point;
                return start;
            }
            if (number == 1)
            {
                new_point.next_person = start;
                start.previous_person = new_point;
                start = new_point;
                return start;
            }
            TwoList current_point = start;
            for (int i = 1; i < number - 1 && current_point != null; i++) current_point = current_point.next_person;
            if (current_point == null)
            {
                Console.WriteLine("Ошибка! Размер списка меньше заданного числа!");
                return start;
            }
            new_point.next_person = current_point.next_person;
            new_point.previous_person = current_point;
            current_point.next_person = new_point;
            if (new_point.next_person != null)
                new_point.next_person.previous_person = new_point;
            return start;
        }
        public static TwoList Delete(TwoList beg)
        {
            if (beg == null) Console.WriteLine("Список пустой!");
            else
            {
                beg = null;
                Console.WriteLine("Список удален");
            }
            return beg;
        }
        static void TwoListMenu()
        {
            Console.WriteLine("1. Сформировать двунаправленный список");
            Console.WriteLine("2. Распечатать двунаправленный список");
            Console.WriteLine("3. Добавление элемента с заданным номером");
            Console.WriteLine("4. Удаление списка из памяти");
            Console.WriteLine("5. Выход");
        }
        static void TwoListMainMenu()
        {
            TwoList start = null;
            int choice = 0;
            do
            {
                TwoListMenu();
                choice = InputNumber("", 1, 5);
                switch (choice)
                {
                    case 1:
                        start = MakeTwoList();
                        break;
                    case 2:
                        ShowList(start);
                        break;
                    case 3:
                        int number = InputNumber("Введите номер:  ", 1);
                        Random rand = new Random();
                        start = AddPoint(start, number, rand);
                        break;
                    case 4:
                        start = Delete(start);
                        break;
                }
            } while (choice < 5);
        }
        #endregion
        #region Tree
        public static Tree Making_Tree(int size, Tree tree)
        {
            int left_size = size / 2;
            int right_size = size - left_size - 1;
            if (size == 0)
            {
                tree = null;
                return tree;
            }
            Tree new_tree = new Tree(Random_element());
            new_tree.left = Making_Tree(left_size, new_tree.left);
            new_tree.right = Making_Tree(right_size, new_tree.right);
            tree = new_tree;
            return tree;
        }
        public static Tree IdealTree(int size)
        {
            Tree tree = null;
            tree = Making_Tree(size, tree);
            Console.WriteLine("Дерево создано");
            return tree;
        }

        public static void ShowTree(Tree tree, int size)
        {
            if (tree != null)
            {
                ShowTree(tree.left, size + 3);
                for (int i = 0; i < size; i++) Console.Write(" ");
                Console.WriteLine(tree.person);
                ShowTree(tree.right, size + 3);
            }
        }
        public static Tree Search_Tree(ref Tree root, Person person)
        {
            Tree tree = root;
            Tree node = null;
            int result = new SortByName().Compare(person, root.person);
            bool ok = false;
            while (tree != null && !ok)
            {
                node = tree;
                result = new SortByName().Compare(person, tree.person);
                if (result == 0) ok = true;
                else
               if (result < 0) tree = tree.left;
                else tree = tree.right;
            }
            if (ok) return tree;
            Tree NewPoint = new Tree(person);
            result = new SortByName().Compare(person, node.person);
            if (result < 0) node.left = NewPoint;
            else node.right = NewPoint;
            return NewPoint;
        }
        public static Tree Delete(Tree tree)
        {
            tree = null;
            return tree;
        }
        public static Tree Run(Tree tree, Tree search_tree)
        {
            if (tree != null)
            {
                Search_Tree(ref search_tree, tree.person);
                Run(tree.left, search_tree);
                Run(tree.right, search_tree);
            }
            return search_tree;
        }
        public static void Find_Person(Tree tree, Person person, ref int count)
        {
            if (tree != null)
            {
                if (tree.person == person) count++;
                Find_Person(tree.left, person, ref count);
                Find_Person(tree.right, person, ref count);
            }
        }
        static void TreeMenu()
        {
            Console.WriteLine("1. Сформировать идеально сбалансированное дерево");
            Console.WriteLine("2. Распечатать идеально сбалансированное дерево");
            Console.WriteLine("3. Преобразовать в дерево поиска");
            Console.WriteLine("4. Выполнить поиск по ключу");
            Console.WriteLine("5. Удалить дерево");
            Console.WriteLine("6. Выход");
        }
        static void TreeMainMenu()
        {
            Tree tree = null;
            int choice = 0, size = 10;
            do
            {
                TreeMenu();
                choice = InputNumber("", 1, 7);
                switch (choice)
                {
                    case 1:
                        tree = IdealTree(size);
                        break;
                    case 2:
                        if (tree != null) ShowTree(tree, 3);
                        else Console.WriteLine("Дерево не содержит элементы!");
                        break;
                    case 3:
                        if (tree != null)
                        {
                            Tree SearchTree = new Tree(tree.person);
                            SearchTree = Run(tree, SearchTree);
                            tree = SearchTree;
                            Console.WriteLine("Дерево поиска:");
                            ShowTree(tree, 3);
                        }
                        else Console.WriteLine("Дерево не содержит элементы!");
                        break;
                    case 4:
                        if (tree != null)
                        {
                            string name = string.Empty;
                            do
                            {
                                Console.WriteLine("Введите фамилию: ");
                                name = Console.ReadLine();
                                if (name == string.Empty) Console.WriteLine("Ошибка! Введите фамилию");
                            } while (name == string.Empty);
                            Console.WriteLine("Введите возраст: ");
                            int age = InputNumber("Введите возраст от 20 до 60: ", 20, 59);
                            Person person = new Person(name, age);
                            int count = 0;
                            Find_Person(tree, person, ref count);
                            Console.WriteLine("Найдено {0} человек", count);
                        }
                        else Console.WriteLine("Дерево не содержит элементы!");
                        break;
                    case 5:
                        if (tree != null)
                        {
                            tree = Delete(tree);
                            Console.WriteLine("Дерево удалено");
                        }
                        else Console.WriteLine("Дерево не содержит элементы!");
                        break;
                }
            } while (choice < 6);
        }
        #endregion
        static void Main(string[] args)
        {
            Run();
        }
    }
}