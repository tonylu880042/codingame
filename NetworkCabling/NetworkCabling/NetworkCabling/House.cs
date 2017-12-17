using System;
using System.Collections.Generic;

namespace NetworkCabling
{
    public class House
    {
        public long x;
        public long y;
        House leftHouse = null;
        House rightHouse = null;
        List<House> evenHouses = new List<House>();
        public static int Length = 0;
        public House()
        {
            
        }

        public long CountCabling(House root)
        {
            long x = 0;
            long y = 0;
            long leftSum = 0;
            long rightSum = 0;

            if (this.leftHouse != null)
                leftSum = this.leftHouse.CountCabling(this);
            if (this.rightHouse != null)
                rightSum = this.rightHouse.CountCabling(this);
            
            if(this.x < root.x)
            {
                x = root.x - this.x; 
            }
            else{
                x = this.x - root.x;
            }

            if(this.y < root.y)
            {
                y = root.y - this.y;
            }
            else
            {
                y = this.y - root.y;
            }

            foreach(var h in this.evenHouses){
                if (h.y > this.y)
                    y = y + (h.y - this.y);
                else{
                    y = y + (this.y - h.y);
                }                        
            }

            return x + y + leftSum + rightSum;
        }
        public void AddNode(House h)
        {
            if(this.x<h.x)
            {
                if (this.rightHouse == null)
                    this.rightHouse = h;
                else
                    this.rightHouse.AddNode(h);
            }//if
            else if(this.x > h.x)
            {
                if (this.leftHouse == null)
                    this.leftHouse = h;
                else
                    this.leftHouse.AddNode(h);
            }//else if
            else{
                this.evenHouses.Add(h);
            }//else
        }//AddNode
    }//House
}
