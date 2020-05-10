using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab12;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            OneList list_1 = null;
            list_1 = Program.Delete(list_1);
            Assert.AreEqual(list_1, null);
            Program.Delete_Element(null);
            Person person = new Person();
            list_1 = new OneList();
            Program.Delete_Element(list_1);
            list_1 = new OneList(person);
            list_1 = Program.MakeOneList();
            Program.Delete_Element(list_1);
            list_1 = Program.MakeOneList();
            list_1 = Program.Delete_Element(list_1);
            list_1 = Program.Delete_Element(list_1);
            list_1 = Program.Delete(list_1);
            Assert.AreEqual(list_1, null);
        }
        [TestMethod]
        public void two_list()
        {
            Person person = new Person();
            TwoList twoList = null;
            twoList = Program.Delete(twoList);
            Program.ShowList(twoList);
            Program.AddPoint(twoList, 10, new Random());
            twoList = new TwoList();
            twoList = Program.MakeTwoList();
            twoList = Program.Make_Two_List_Person(person);
            twoList = Program.AddPoint(twoList, 1, new Random());
            twoList = Program.AddPoint(twoList, 3, new Random());
            twoList = Program.MakeTwoList();
            twoList = Program.AddPoint(twoList, 20, new Random());
            twoList = Program.AddPoint(twoList, 40, new Random());
            twoList = Program.Delete(twoList);
            Assert.AreEqual(twoList, null);
        }
        [TestMethod]
        public void tree()
        {
            Person person = new Person();
            Tree tree = new Tree();
            tree = null;
            tree = Program.Delete(tree);
            Assert.AreEqual(tree, null);
            tree = Program.IdealTree(10);
            Tree search_tree = new Tree(person);
            search_tree = Program.Run(tree, search_tree);
            tree = search_tree;
            tree = Program.IdealTree(100);
            search_tree = new Tree(person);
            search_tree = Program.Run(tree, search_tree);
            tree = search_tree;
            tree = Program.Delete(tree);
            Assert.AreEqual(tree, null);
        }
    }
}
