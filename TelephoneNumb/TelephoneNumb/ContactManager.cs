using System;
using System.Collections.Generic;

namespace TelephoneNumb
{
    public class TreeNode
    {
        public static int totalNodes = 0;
        public string digi;
        public int pos;
        public List<TreeNode> numbers;
        public TreeNode(){
            this.numbers = new List<TreeNode>();
        }

        public bool ExistDigiNode(string digi){
            return this.numbers.Exists(x => x.digi == digi);        
        }
        public TreeNode Add(string digi)
        {
            if (this.ExistDigiNode(digi) == false)
            {
                TreeNode.totalNodes++;
                TreeNode node = new TreeNode();
                node.digi = digi;
                this.numbers.Add(node);
                return node;
            }
            else{
                return this.numbers.Find(x => x.digi == digi);
            }
        }
    }
    public class ContactManager
    {
        int digiCount = 0;
        TreeNode root = null;
        public void ResetNodeCounts()
        {
            TreeNode.totalNodes = 0;
        }
        public ContactManager()
        {
            root = new TreeNode();
        }

        public void AddContacts(String phoneNo){
            
            char[] digis = phoneNo.ToCharArray();
            TreeNode current = null;
            foreach(char digi in digis){
                if(current == null){
                    current = root;
                }//if
                current = current.Add(digi.ToString());
            }
        }
        public int CountNodes(){            
            return TreeNode.totalNodes;
        }
    }
}
