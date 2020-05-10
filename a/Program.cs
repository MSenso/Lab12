using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a
{
    class Point
    {
        public KeyValuePair<string, int> data;
        public Point left, right;
        public Point()
        {
            data = new KeyValuePair<string, int>(string.Empty, 0);
            left = null;
            right = null;
        }
        public Point(KeyValuePair<string,int> d)
        {
            data = d;
            left = null;
            right = null;
        }
        public override string ToString()
        {
            return data.ToString() + " ";
        }
    }
    class Program
    {
        static string[] names = { "Иванов", "Иванова", "Петров", "Петрова", "Сидоров", "Сидорова", "Кузнецов", "Кузнецова", "Соколов", "Соколова", "Галкин", "Галкина" };

        static Point MakePoint(KeyValuePair<string,int> d)//формирование  элемента дерева
        {
            Point p = new Point(d);
            return p;
        }
        static int Compare(KeyValuePair<string,int> d_1, KeyValuePair<string,int> d_2)
        {
            int result = String.Compare(d_1.Key, d_2.Key);
            if (result == 0)
            {
                if (d_1.Value < d_2.Value) result = -1;
                else if (d_1.Value > d_2.Value) result = 1;
            }
            return result;
        }
        static Point Add(ref Point root, KeyValuePair<string, int> d)
        {
            Point p = root;//корень дерева
            Point r = null;
            int result = Compare(d, p.data);
            //флаг для проверки существования элемента d в дереве
            bool ok = false;
            while (p != null && !ok)
            {

                r = p;
                result = Compare(d, p.data);
                if (result == 0) ok = true;//элемент уже существует
                else
               if (result < 0) p = p.left;//пойти в левое поддерево
                else p = p.right; //пойти в правое поддерево
            }
            if (ok) return p;//найдено, не добавляем
                             //создаем узел
            Point NewPoint = MakePoint(d);//выделили память
            result = Compare(d, r.data);
            // если d<r->key, то добавляем его в левое поддерево
            if (result < 0) r.left = NewPoint;
            // если d>r->key, то добавляем его в правое поддерево
            else r.right = NewPoint;
            return NewPoint;
        }
        static Random random = new Random();
        public static Point Run(Point p, Point search)
        {

            if (p != null)
            {
                Add(ref search, p.data);
                Run(p.left, search);
                Run(p.right, search);
            }
            return search;
        }
        static Point Making_Tree(int size, Point tree)
        {
            int left_size = size / 2;
            int right_size = size - left_size - 1;
            if (size == 0) { tree = null; return tree; }
            Point new_tree = new Point(new KeyValuePair<string, int>(names[random.Next(0, 12)], random.Next(20, 70)));
            new_tree.left = Making_Tree(left_size, new_tree.left);
            new_tree.right = Making_Tree(right_size, new_tree.right);
            tree = new_tree;
            return tree;
        }
        static void ShowTree(Point tree, int size)
        {
            if (tree != null)
            {
                ShowTree(tree.left, size + 3);
                for (int i = 0; i < size; i++) Console.Write(" ");
                Console.WriteLine(tree.data);
                ShowTree(tree.right, size + 3);
            }
        }
        static void Main(string[] args)
        {
            Point tree = null;
            int size = 5;
            tree = Making_Tree(size, tree);
            ShowTree(tree, 5);
            Point search = new Point(tree.data);
            search = Run(tree, search);
            tree = search;
            Console.WriteLine();
            Console.WriteLine();
            ShowTree(tree, 5);
        }
    }
}
