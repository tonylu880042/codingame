using System;
using System.Collections.Generic;
using System.Linq;

namespace Dwarfs
{
    public class Node
    {
        public static int result = 0;
        public string digi;
        public int depth;
        public List<Node> children = new List<Node>();
        public List<Node> parents = new List<Node>();
        public List<Node> traversedPath = null;

        public Node()
        {
        }

        public bool ExistDigiNode(string digi)
        {
            return this.children.Exists(x => x.digi == digi);
        }

        public static int CountDepth(Node node, List<Node> path)
        {
            if (path.Find(x => x.digi == node.digi) == null)
            {
                path.Add(node);
                foreach (Node n in node.children)
                {
                    if (path.Find(x => x.digi == n.digi) == null )
                    {
                        //if (n.traversedPath == null)
                        //{
                            CountDepth(n, path);
                        //}
                        //else
                        //{
                            //if (node.depth < n.traversedPath.Count())
                            //    node.depth = n.traversedPath.Count() + 1;
                        //}
                    }//
                }//for
                if (node.depth < path.Count)
                {
                    node.depth = path.Count;
                    node.traversedPath = path.ToList();
                    if (Node.result < node.depth)
                        Node.result = node.depth;
                }
                path.Remove(node);
            }//if
            return result;
        }


        public void AddChildNode(Node node)
        {            
            this.children.Add(node); 
            node.parents.Add(this);
        }//
    
    }//TreeNode

    public class NodeManager{
        Dictionary<string, Node> nodes = new
            Dictionary<string, Node>();
        Node root = null;
        public void AddNode(string n1,string n2){
            Node no1 = null, no2 = null;
            if (nodes.ContainsKey(n1) == false)
            {
                no1 = new Node();
                no1.digi = n1;
                nodes[n1] = no1;
                root = no1;
            }else{
                no1 = nodes[n1];
            }

            if (nodes.ContainsKey(n2) == false)
            {
                no2 = new Node();
                no2.digi = n2;
                nodes[n2] = no2;
            }
            else
            {
                no2 = nodes[n2];
            }

            no1.AddChildNode(no2);

        }
        public List<Node> FindRoots(){

            List<Node> dataSet = nodes.Values.ToList();
            return dataSet.FindAll(x=>x.parents.Count == 0);

        }
    }
}
