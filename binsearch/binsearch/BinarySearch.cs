using System;
namespace binsearch
{
    public class BinarySearch
    {
        public int TargetX { get; set; }
        public int TargetY { get; set; }

        public int H { get; set; }
        public int W { get; set; }

        public int X0 { get; set; }
        public int Y0 { get; set; }

        public int left = 0;
        public int right = 0;
        public int top = 0;
        public int bottom = 0;
        public int mx {get; set;}
        public int my {get; set;}

        public int round = 0;

        public BinarySearch()
        {
            this.TargetX = 0;
            this.TargetY = 0;
        }
        public void Init(){
            this.right = W;
            this.bottom = H;
		    mx = X0;
			my = Y0;
            round = 0;
        }

        public bool found()
        {
            if (my == TargetY && mx == TargetX){
                return true;            
            }
            else
            {
                return false;
            }
        }


        public string getHint(int cx,int cy){

            string x = "";
            string y = "";
            if(TargetX == cx)
            {
                x = "";
            }
            else if (TargetX > cx)
            {
                x = "R";
            }    
            else
            {
                x = "L";
            }
            if(TargetY == cy){
                y = "";
            }
            else if (TargetY > cy)
			{
				y = "D";
			}
			else
			{
				y = "U";
			}

            return y+x;
        }

        public int[] DoSearch(string bombDir)
        {
            round++;
			int xdiff = 0;
			int ydiff = 0;
            switch (bombDir)
			{
				case "U":
					bottom = my;
					if ((bottom - top) % 2 != 0)
						ydiff = (int)((bottom - top + 1) / 2);
					else
						ydiff = (int)((bottom - top) / 2);
					
                    if(ydiff == 0)
					    ydiff = 1;
                    
					my = my - ydiff;
                    //if (my < 0) my = 0;
					break;

				case "UR":
					bottom = my;
					left = mx;

					if ((right - left) % 2 != 0)
						xdiff = (int)((right - left + 1) / 2);
					else
						xdiff = (int)((right - left) / 2);
                    if((bottom - top) %2 != 0)
    					ydiff = (int)((bottom - top-1) / 2);
                    else
                        ydiff = (int)((bottom - top) / 2);
					
                    if (ydiff == 0)
						ydiff = 1;
					if (xdiff == 0)
						xdiff = 1;
					mx = mx + xdiff;
					my = my - ydiff;

					break;
				case "R":
					left = mx;

					if ((right - left) % 2 != 0)
						xdiff = (int)((right - left + 1) / 2);
					else
						xdiff = (int)((right - left) / 2);

					if (xdiff == 0)
						xdiff = 1;
					mx = mx + xdiff;
					break;
				case "DR":
					top = my;
					left = mx;

					if ((right - left) % 2 != 0)
						xdiff = (int)((right - left + 1) / 2);
					else
						xdiff = (int)((right - left) / 2);


					if ((bottom - top) % 2 != 0)
						ydiff = (int)((bottom - top + 1) / 2);
					else
						ydiff = (int)((bottom - top) / 2);
                    
                    if (ydiff == 0)
						ydiff = 1;
                    
					if (xdiff == 0)
						xdiff = 1;
					
                    mx = mx + xdiff;
					my = my + ydiff;
					break;
				case "D":
					top = my;
					if ((bottom - top) % 2 != 0)
						ydiff = (int)((bottom - top + 1) / 2);
					else
						ydiff = (int)((bottom - top) / 2);
					if (ydiff == 0)
						ydiff = 1;
					my = my + ydiff;
					break;
				case "DL":
					top = my;
					right = mx;
					if ((right - left) % 2 != 0)
						xdiff = (int)((right - left - 1) / 2);
					else
						xdiff = (int)((right - left) / 2);
					if ((bottom - top) % 2 != 0)
						ydiff = (int)((bottom - top + 1) / 2);
					else
						ydiff = (int)((bottom - top) / 2);
					if (ydiff == 0)
						ydiff = 1;
                    if (xdiff == 0)
                        xdiff = 1;
					my = my + ydiff;
					mx = mx - xdiff;
					break;
				case "L":
					right = mx;
					if ((right - left) % 2 != 0)
						xdiff = (int)((right - left - 1) / 2);
					else
						xdiff = (int)((right - left) / 2);
                    if (xdiff == 0)
                        xdiff = 1;
                    mx = mx - xdiff;
					break;
				case "UL":
					right = mx;
					bottom = my;
					if ((right - left) % 2 != 0)
						xdiff = (int)((right - left - 1) / 2);
					else
						xdiff = (int)((right - left) / 2);
					ydiff = (int)((bottom - top) / 2);
					if (ydiff == 0)
						ydiff = 1;
					my = my - ydiff;
                    if (mx > 0)
                    {
                        if (xdiff > 0)
                            mx = mx - xdiff;
                        else
                            mx = mx - 1;
                    }
                    else
                        mx = 0;
					break;
			}//switch
            int[] result = new int[2];
            result[0] = mx;
            result[1] = my;
            return result;
        }

    }
}
