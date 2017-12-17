using System;
using System.Collections.Generic;
using System.Linq;

namespace NetworkCabling
{
    public class HouseMap
    {
        private List<House> houses = new List<House>();
        private House root = null;
        long max_x = 0;
        long min_x = 0;
        public HouseMap()
        {
            
        }
        public long CalLength()
        {
            return root.CountCabling(root);
        }
        public void Add(long x,long y)
        {

            if(this.houses.Count == 0)
            {
                max_x = x;
                min_x = x;
            }

            House h = new House();
            h.x = x;
            h.y = y;
            houses.Add(h);

            if (x >= max_x)
                max_x = x;
            else if (x <= min_x)
                min_x = x;
           

            /*
            if(root == null)
            {
                
                root = h;
            }
            else
            {
                root.AddNode(h);
            }
            */
        }

        public long getMainCableLength()
        {
            return this.max_x - this.min_x;
        }
        public long getHouseToMainCableLength()
        {
            this.houses.Sort((i, j) => i.y.CompareTo(j.y));
            //midian number
            long result = 0; 
            House h = this.houses[this.houses.Count / 2];
            foreach (House a in this.houses)
            {
                if (a.y > h.y)
                    result = result + (a.y - h.y);
                else
                    result = result + (h.y - a.y);
                
            }
            return result;
        }

    }
}
