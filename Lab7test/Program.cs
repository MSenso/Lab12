using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication3
{


    class BinaryTree
    {
        public int data;
        public BinaryTree left, right;
        public BinaryTree()
        {
            data = 0;
            left = null;
            right = null;
        }
        public BinaryTree(int d)
        {
            data = d;
            left = null;
            right = null;
        }
        public override string ToString()
        {
            return data + " ";
        }

    }
    class Program
    {
  static Random rnd = new Random();

        static BinaryTree MakeTree(BinaryTree p, int size)
        {
            Console.WriteLine(@"Каким образом сформировать бинарное дерево:
1. ДСЧ
2. С клавиатуры");
            int check = ReadIntNumber("", 1, 3);
            switch (check)
            {
                case 1:
                    p = RandomTree(size, p);
                    break;
                case 2:
                    p = Tree(size, p);
                    break;
            }
            return p;
        }



        static BinaryTree RandomTree(int size, BinaryTree p)
        {
            BinaryTree r;
            int nl, nr;
            if (size == 0) { p = null; return p; }
            nl = size / 2;
            nr = size - nl - 1;
            int d = rnd.Next(-99, 100);
            Console.WriteLine("The element {0} is adding...", d);
            r = new BinaryTree(d);
            r.left = RandomTree(nl, r.left);
            r.right = RandomTree(nr, r.right);
            p = r;
            return p;
        }

        static BinaryTree Tree(int size, BinaryTree p)
        {
            BinaryTree r;
            int nl, nr;
            if (size == 0) { p = null; return p; }
            nl = size / 2;
            nr = size - nl - 1;
            int d = ReadIntNumber("", -99, 100);
            Console.WriteLine("The element {0} is adding...", d);
            r = new BinaryTree(d);
            r.left = Tree(nl, r.left);
            r.right = Tree(nr, r.right);
            p = r;
            return p;
        }

        static void ShowTree(BinaryTree p, int l)
        {
            if (p != null)
            {
                ShowTree(p.left, l + 3);
                for (int i = 0; i < l; i++) Console.Write(" ");
                Console.WriteLine(p.data);
                ShowTree(p.right, l + 3);
            }
        }
        public static void FindMax(BinaryTree p, ref int number)
        {
            if (p != null)
            {
                FindMax(p.left, ref number);
                if (p.data > number) number = p.data;
                FindMax(p.right, ref number);
            }
        }

        static BinaryTree MakeSearchTree(ref BinaryTree root, int d)
        {
            BinaryTree p = root;
            BinaryTree r = null;
            bool Ok = false;
            while (p != null && !Ok)
            {
                r = p;
                if (d == p.data)
                {
                    Ok = true;
                }
                else
                {
                    if (d < p.data)
                    {
                        p = p.left;
                    }
                    else
                    {
                        p = p.right;
                    }
                }
            }
            if (Ok)
            {
                return p;
            }
            else
            {
                BinaryTree NewTree = new BinaryTree(d);
                if (d < r.data)
                {
                    r.left = NewTree;
                }
                else
                {
                    r.right = NewTree;
                }
                return root;
            }
        }

        static BinaryTree Run(BinaryTree r, BinaryTree P)
        {
            if (r != null)
            {
                MakeSearchTree(ref P, r.data);
                Run(r.left, P);
                Run(r.right, P);
            }
            return P;
        }
        static void FoundMax(BinaryTree r, ref int Max)
        {
            if (r != null)
            {
                if (r.data > Max)
                {
                    Max = r.data;
                }
                FoundMax(r.left, ref Max);
                FoundMax(r.right, ref Max);
            }
        }


        static int ReadIntNumber(string stringForUser, int left, int right)
        {
            bool okInput = false;
            int number = -100;
            do
            {
                Console.WriteLine(stringForUser);
                try
                {
                    string buf = Console.ReadLine();
                    number = Convert.ToInt32(buf);
                    if (number >= left && number < right) okInput = true;
                    else
                    {
                        Console.WriteLine("Неверно введено число!");
                        okInput = false;
                    }
                }
                catch
                {
                    Console.WriteLine("Неверно введено число!");
                    okInput = false;
                }
            } while (!okInput);
            return number;
        }


        static void RunMenu(int size, BinaryTree beg3)
        {
            int check = 0;
            do
            {
                Console.WriteLine(@"1. Работа с однонаправленным списком
2. Работа с двунаправленным списком
3. Работа с деревом
4. Выход");
                check = ReadIntNumber("", 1, 5);
                switch (check)
                {
                    
                    case 3:
                        RunMenuBinaryTree(size, beg3);
                        break;
                    case 4:

                        break;
                    default:
                        Console.WriteLine("Ошибка!");
                        break;
                }
            } while (check < 4);
        }

        static void RunMenuBinaryTree(int size, BinaryTree beg3)
        {
            int check = 0;
            do
            {
                Console.WriteLine(@"1. Сформировать бинарное дерево
2. Распечатать бинарное дерево
3. Найти максимальный элемент в дереве
4. Удалить бинарное дерево дерево
5. Назад");
                check = ReadIntNumber("", 1, 6);
                switch (check)
                {
                    case 1:
                        size = ReadIntNumber("Введите размер бинарного дерева:", 1, 20);
                        beg3 = MakeTree(beg3, size);
                        break;
                    case 2:
                        if (beg3 != null)
                        {
                            ShowTree(beg3, 5);
                        }
                        else Console.WriteLine("Бинарное дерево не сформировано");
                        break;
                    case 3:
                        {
                            int Max = int.MinValue;
                            FoundMax(beg3, ref Max);
                            Console.WriteLine($"Максимальное значение равно = {Max}");
                            BinaryTree SearchTree = new BinaryTree(beg3.data);
                            SearchTree = Run(beg3, SearchTree);
                            beg3 = SearchTree;
                            ShowTree(beg3, 3);
                            Max = int.MinValue;
                            FoundMax(beg3, ref Max);
                            Console.WriteLine($"Максимальное значение равно = {Max}");
                        }
                        break;

                    case 4:
                        beg3 = null;

                        break;
                    case 5:
                        RunMenu(size, beg3);
                        break;
                    default:
                        Console.WriteLine("Ошибка!");
                        break;
                }
            } while (check < 5);
        }


        static void Main(string[] args)
        {
            BinaryTree beg3 = null;
            int size = 0;
            RunMenu(size, beg3);
        }
    }
}
