using System;
using System.Collections.Generic;
using System.Linq;

namespace Teads
{
    public class Node
    {
        private string id;
        private int depth;
        private List<Node> linkTo = new List<Node>();
        public List<Node> traversedPath = null;
        public List<Node> parents=new List<Node>();
        public List<Node> children=new List<Node>();


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
        public void CalChildLevelCount(Node node)
        {
            
        }

        public int CountDepth(Node node,List<Node> path)
        {
            if(path.Find(x=>x.GetId() == node.GetId())==null)
            {
                path.Add(node);
                foreach(Node n in node.GetAllLinkedNodes())
                {
                    if (path.Find(x => x.GetId() == n.GetId()) == null ) {
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
                }
                    
                path.Remove(node);
            }//if

            return depth;
        }
    }
}
