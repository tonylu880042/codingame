using System;
using System.Collections.Generic;
using System.Linq;

namespace Teads
{
    public class Node
    {
        private string id;
        public int depth;
        public static int result = 0;
        private List<Node> linkTo = new List<Node>();
        public List<Node> traversedPath = null;


        public int GetDepthNo(){
            return this.depth;
        }
        public Node()
        {
            
        }
        public string GetId(){
            return this.id;
        }
        public void SetId(string id)
        {
            this.id = id;
        }
        public int GetFriendCount(){
            return this.linkTo.Count;
        }
        public void Add(Node node)
        {
            this.linkTo.Add(node);
        }
        public List<Node> GetAllLinkedNodes(){
            return this.linkTo;
        }
        public override string ToString()
        {
            return string.Format("[Node.id]{0}",this.id);
        }

        public int CountDepth(Node node,List<Node> path)
        {
            if(path.Find(x=>x.GetId() == node.GetId())==null)
            {
                path.Add(node);
                foreach(Node n in node.GetAllLinkedNodes())
                {
                    if (path.Find(x => x.GetId() == n.GetId()) == null && n.GetFriendCount() >1) {
                        if(n.traversedPath == null){                            
                            CountDepth(n, path);
                        }
                        else{
                            if (node.depth < n.traversedPath.Count())
                                node.depth = n.traversedPath.Count() + 1;
                        }                                
                    }//
                }//for
                if(node.depth<path.Count)
                {
                    node.depth = path.Count;
                    node.traversedPath = path.ToList();
                    if (Node.result < node.depth)
                        Node.result = node.depth;
                }                    
                path.Remove(node);
            }//if
            return depth;
        }
    }
}
