using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Teads
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase()
        {
            /*
                7
                1 2
                2 3
                3 4
                3 7
                4 5
                4 6
                7 8
            */
            string data = @"6 8
15 1
1 14
0 3
15 13
9 15
2 5
14 10
4 9
7 2
8 7
3 4
1 6";
            string[] toks = data.Split('\n');

            Dictionary<string,Node> nodes = new Dictionary<string, Node>();

            for (int a = 0; a < toks.Length;a++)
            {
                string[] input = toks[a].Trim().Split(' ');

                //
                Node theLeftNode = null;
                Node theRightNode = null;

                try{
                    theLeftNode = nodes[input[0]];
                }catch(Exception e){
                    Console.WriteLine( e.StackTrace);
                }
                try
                {
                    theRightNode = nodes[input[1]];
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }

                if(theLeftNode == null)
                {
                    theLeftNode = new Node();
                    theLeftNode.SetId(input[0]);
                    nodes.Add(input[0],theLeftNode);
                }//if

                if (theRightNode == null)
                {
                    theRightNode = new Node();
                    theRightNode.SetId(input[1]);
                    nodes.Add(input[1],theRightNode);
                }//if

                theLeftNode.Add(theRightNode);
                theRightNode.Add(theLeftNode);
            }//for

            //determine the starting point
            Node theNode = null;
            List<Node> nodeList = nodes.Values.ToList();
            foreach (Node n in nodeList)
            {
                if (n.GetFriendCount() == 1)
                {
                    theNode = n;
                    break;
                }                
            }

            //find the node with max links
            List<Node> path = new List<Node>();
            //var count = 0;
            theNode.CountDepth(theNode, path);
            //find the max count of the link in the node list
            //nodes = nodes.OrderByDescending(x => x.GetDepthNo()).ToList();
            //theNode = nodes[0];

            int length = (int)Math.Round((double)(Node.result - 1) / 2,0,MidpointRounding.AwayFromZero);
            Console.WriteLine("Depth=" + length.ToString() + " from ObjID:"
                              + theNode.GetId().ToString());
            /*
            foreach(Node theNode in nodes){
                
                if(theNode.GetFriendCount() == 1)
                {    
                    theNode.CountDepth(theNode,path);
                    count++;
                }
            }

            Console.WriteLine("Total Search Time:" + count.ToString());
            nodes = nodes.OrderByDescending(x => x.GetDepthNo()).ToList();

            foreach( Node theNode2 in nodes){
                
                int length = (int) Math.Round((double)(theNode2.GetDepthNo()-1)/ 2);

                Console.WriteLine("Depth="+length.ToString() + " from ObjID:"
                              + theNode2.GetId().ToString());
                break;
            }*/

        }              
    }
}
