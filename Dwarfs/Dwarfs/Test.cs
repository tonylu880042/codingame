using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Dwarfs
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase01()
        {

            NodeManager mgr = new NodeManager();
            mgr.AddNode("1","2");
            mgr.AddNode("1", "3");
            mgr.AddNode("3", "4");
            List<Node> path = new List<Node>();
            List<Node> roots = mgr.FindRoots();
            int result = 0;
            foreach (Node r in roots)
            {
                Node.result = 0;
                int d = Node.CountDepth(r, path);
                if (d > result)
                    result = d;
            }
            Assert.AreEqual(3, result);

        }
        [Test()]
        public void TestCase02()
        {

            NodeManager mgr = new NodeManager();
            mgr.AddNode("1", "2");
            mgr.AddNode("1", "3");
            mgr.AddNode("3", "4");
            mgr.AddNode("2", "4");
            mgr.AddNode("2", "5");
            mgr.AddNode("10", "11");
            mgr.AddNode("10", "1");
            mgr.AddNode("10", "3");
            List<Node> path = new List<Node>();
            List<Node> roots = mgr.FindRoots();
            int result = 0;
            foreach (Node r in roots)
            {
                Node.result = 0;
                int d = Node.CountDepth(r, path);
                if (d > result)
                    result = d;
            }
            Assert.AreEqual(4, result);

        }
        [Test()]
        public void TestCase03()
        {
            /*
            2 3
8 9
1 2
6 3
            */
            NodeManager mgr = new NodeManager();
            mgr.AddNode("2", "3");
            mgr.AddNode("8", "9");
            mgr.AddNode("1", "2");
            mgr.AddNode("6", "3");

            List<Node> path = new List<Node>();
            List<Node> roots = mgr.FindRoots();
            int result = 0;
            foreach(Node r in roots)
            {
                Node.result = 0;
                int d = Node.CountDepth(r, path);
                if (d > result)
                    result = d;
            }
            Assert.AreEqual(3,result);

        }

        [Test()]
        public void TestCase04()
        {
            /*
 (1,2),(2,3),(2,4),(3,4),(4,5)
            */
            NodeManager mgr = new NodeManager();
            mgr.AddNode("1", "2");
            mgr.AddNode("2", "3");
            mgr.AddNode("2", "4");
            mgr.AddNode("3", "4");
            mgr.AddNode("4", "5");

            List<Node> path = new List<Node>();
            List<Node> roots = mgr.FindRoots();
            int result = 0;
            foreach (Node r in roots)
            {
                Node.result = 0;
                int d = Node.CountDepth(r, path);
                if (d > result)
                    result = d;
            }
            Assert.AreEqual(5, result);
            // (1 2)(1 3)(1 4)(3 2)(4 5)
        }
        [Test()]
        public void TestCase05()
        {
            /*
             * // (1 2)(1 3)(1 4)(3 2)(4 5)
            */
            NodeManager mgr = new NodeManager();
            mgr.AddNode("1", "2");
            mgr.AddNode("1", "3");
            mgr.AddNode("1", "4");
            mgr.AddNode("3", "2");
            mgr.AddNode("4", "5");

            List<Node> path = new List<Node>();
            List<Node> roots = mgr.FindRoots();
            int result = 0;
            foreach (Node r in roots)
            {
                Node.result = 0;
                int d = Node.CountDepth(r, path);
                if (d > result)
                    result = d;
            }
            Assert.AreEqual(3, result);

        }
        [Test()]
        public void TestCase06()
        {
            /*
             * //(1 2)(1 3)(1 4)(1 5)(2 6)(2 7)(3 8)(4 8)(5 8)(7 9)(7 10)(7 11)(8 9) 
            */
            NodeManager mgr = new NodeManager();
            mgr.AddNode("1", "2");
            mgr.AddNode("1", "3");
            mgr.AddNode("1", "4");
            mgr.AddNode("1", "5");
            mgr.AddNode("2", "6");
            mgr.AddNode("2", "7");
            mgr.AddNode("3", "8");
            mgr.AddNode("4", "8");
            mgr.AddNode("5", "8");
            mgr.AddNode("7", "9");
            mgr.AddNode("7", "10");
            mgr.AddNode("7", "11");
            mgr.AddNode("8", "9");
            List<Node> path = new List<Node>();
            List<Node> roots = mgr.FindRoots();
            int result = 0;
            foreach (Node r in roots)
            {
                Node.result = 0;
                int d = Node.CountDepth(r, path);
                if (d > result)
                    result = d;
            }
            Assert.AreEqual(4, result);
            //(1 2)(1 3)(1 4)(1 5)(2 6)(2 7)(3 8)(4 8)(5 8)(7 9)(7 10)(7 11)(8 9) 
        }
        [Test()]
        public void TestCase07()
        {
            /*
             * (1,2),(4,3),(3,1) the result is 4
(1,2),(2,3),(4,5),(5,6),(5,2) => 4
(5,6),(5,3),(6,1),(7,4),(6,2),(9,4),(4,5),(2,8) => 6 
            */
            NodeManager mgr = new NodeManager();
            mgr.AddNode("1", "2");
            mgr.AddNode("4", "3");
            mgr.AddNode("3", "1");

            List<Node> path = new List<Node>();
            List<Node> roots = mgr.FindRoots();
            int result = 0;
            foreach (Node r in roots)
            {
                Node.result = 0;
                int d = Node.CountDepth(r, path);
                if (d > result)
                    result = d;
            }
            Assert.AreEqual(4, result);
        }
        [Test()]
        public void TestCase08()
        {
            /*
(1,2),(2,3),(4,5),(5,6),(5,2) => 4
            */
            NodeManager mgr = new NodeManager();
            mgr.AddNode("1", "2");
            mgr.AddNode("2", "3");
            mgr.AddNode("4", "5");
            mgr.AddNode("5", "6");
            mgr.AddNode("5", "2");

            List<Node> roots = mgr.FindRoots();
            int result = 0;
            foreach (Node r in roots)
            {
                Node.result = 0;
                List<Node> path = new List<Node>();
                int d = Node.CountDepth(r, path);
                if (d > result)
                    result = d;
            }
            Assert.AreEqual(4, result);
        }
        [Test()]
        public void TestCase09()
        {
            /*
            (5,6),(5,3),(6,1),(7,4),(6,2),(9,4),(4,5),(2,8) => 6 
            */
            NodeManager mgr = new NodeManager();
            mgr.AddNode("5", "6");
            mgr.AddNode("5", "3");
            mgr.AddNode("6", "1");
            mgr.AddNode("7", "4");
            mgr.AddNode("6", "2");
            mgr.AddNode("9", "4");
            mgr.AddNode("4", "5");
            mgr.AddNode("2", "8");
            List<Node> path = new List<Node>();
            List<Node> roots = mgr.FindRoots();
            int result = 0;
            foreach (Node r in roots)
            {
                Node.result = 0;
                int d = Node.CountDepth(r, path);
                if (d > result)
                    result = d;
            }
            Assert.AreEqual(6, result);

        }
    
    }
}
