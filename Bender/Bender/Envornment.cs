using System;
using System.Collections.Generic;
using System.Text;

namespace Bender
{
    public class Envornment
    {
        int width = 0;
        int height = 0;
        int[] robotPos = new int[2];
        List<int[]> Teleports = new List<int[]>();
        List<string> rawData = new List<string>();
        string[,] map = null;
        public Envornment(int width,int height)
        {
            this.width = width;
            this.height = height;
        }

        public void AddMapData(string line)
        {
            this.rawData.Add(line);
        }

        public string[,] buildMap(){
            
            map = new string[width, height];
            int x=0, y = 0;
            foreach(string line in this.rawData)
            {
                char[] data = line.ToCharArray();
                for (x = 0; x < width;x++)
                {
                    map[x, y] = data[x].ToString();
                    if(map[x, y] == "@")
                    {
                        robotPos[0] = x;
                        robotPos[1] = y;
                    }
                    else if (map[x,y] == "T")
                    {
                        int[] t = new int[2];
                        t[0] = x;
                        t[1] = y;
                        this.Teleports.Add(t);
                    }
                }
                y++;
            }//for
            return map;
        }
        public int[] GetNextTeleport(int x,int y)
        {
            int[] target = null;
            foreach (var t in this.Teleports)
            {
                if (!(t[0] == x && t[1] == y))
                {
                    target = t;
                }
            }
            return target;
        }
        public void updateRobotPos(int x, int y)
        {
            
        }
        public String GetPosInfo(int x,int y)
        {
            try
            {
                if (this.map != null && x >= 0 && y >= 0)
                    return map[x, y];
                else
                    return "#";

            }
            catch(Exception e)
            {
                Console.WriteLine("X:"+x.ToString() + " Y:" + y.ToString());
            }
            return "";
        }
        public int[] GetRobotInitPos()
        {
            return robotPos;
        }

        public void UpdatePosInfo(int x, int y, string data)
        {
            map[x, y] = data;
        }
    }

    public class Log{
        public int x,y;
        public string move;
        public Log(){
                    }
    }
    public class Robot
    {
        public int currentX=-1, currentY=-1;
        public List<Log> logs = new List<Log>();

        Envornment env = null;
        //private Queue<string> priority = new Queue<string>();
        private string priority = "";
        private bool beast = false;
        private bool invert = false;
        private bool loop = false;
        private int loopCount = 0;
        public Robot(Envornment env){
            this.env = env;
            /*priority.Enqueue("SOUTH");
            priority.Enqueue("EAST");
            priority.Enqueue("NORTH");
            priority.Enqueue("WEST");*/
        }
        public Robot()
        {
            
        }

        public string NextMove()
        {
            string move = "";
            if (currentX == -1 && currentY == -1)
            {
                int[] pos = env.GetRobotInitPos();
                if (pos != null)
                {
                    currentX = pos[0];
                    currentY = pos[1];
                }//if

            }
            if (this.env.GetPosInfo(this.currentX, this.currentY) == "T")
            {
                int[] pos = this.env.GetNextTeleport(this.currentX, this.currentY);
                this.currentX = pos[0];
                this.currentY = pos[1];
            }
            else if (this.env.GetPosInfo(this.currentX, this.currentY) == "$")
            {
                return "DONE";
            }
            else if(this.env.GetPosInfo(this.currentX, this.currentY) != "")
            {
                switch (this.env.GetPosInfo(this.currentX, this.currentY))
                {
                    case "S":
                        priority = "SOUTH";
                        break;
                    case "N":
                        priority = "NORTH";
                        break;
                    case "E":
                        priority = "EAST";
                        break;
                    case "W":
                        priority = "WEST";
                        break;
                    case "B":
                        this.beast = !this.beast;
                        break;
                    case "I":
                        this.invert = !this.invert;
                        break;
                }                                    
            }

            //SOUTH, EAST, NORTH and WEST

            move = DetermineDirection();

            //check loop count
            if(loopCount > 1000){
                this.loop = true;
                this.logs.Clear();
                return "LOOP";
            }
                

            return move;
        }//

        private string DetermineDirection()
        {
            string move;
            if (this.priority == "")
                this.priority = "SOUTH";

            if (CheckWayIsOKToMove(this.priority))
            {
                this.MoveTo(this.priority);
                move = this.priority;
            }
            else if (this.invert == false)
                move = ForwardPriorty();
            else 
                move = BackwardPriorty();

            this.priority = move;
            return move;
        }
        private string BackwardPriorty()
        {
            string move;
            if (CheckWayIsOKToMove("WEST"))
            {
                this.MoveTo("WEST");
                move = "WEST";
            }
            else if (CheckWayIsOKToMove("NORTH"))
            {
                this.MoveTo("NORTH");
                move = "NORTH";
            }
            else if (CheckWayIsOKToMove("EAST"))
            {
                this.MoveTo("EAST");
                move = "EAST";
            }
            else if (CheckWayIsOKToMove("SOUTH"))
            {
                this.MoveTo("SOUTH");
                move = "SOUTH";
            }
            else
            {
                move = "LOOP";
            }

            return move;
        }
        private string ForwardPriorty()
        {
            string move;
            if (CheckWayIsOKToMove("SOUTH"))
            {
                this.MoveTo("SOUTH");
                move = "SOUTH";
            }
            else if (CheckWayIsOKToMove("EAST"))
            {
                this.MoveTo("EAST");
                move = "EAST";
            }
            else if (CheckWayIsOKToMove("NORTH"))
            {
                this.MoveTo("NORTH");
                move = "NORTH";
            }
            else if (CheckWayIsOKToMove("WEST"))
            {
                this.MoveTo("WEST");
                move = "WEST";
            }
            else
            {
                move = "LOOP";
            }

            return move;
        }

        public string OuptutPath()
        {
            StringBuilder path = new StringBuilder();
            if (this.loop == false)
            {

                foreach (var log in this.logs)
                {
                    path.AppendLine(log.move);
                }
                return path.ToString();
            }
            else
                return "LOOP\n";
        }
        public void MoveTo(string dir)
        {
            Log log = new Log();
            log.move = dir;
            switch(dir)
            {
                case "SOUTH":
                    this.currentY = this.currentY + 1;
                    break;
                case "EAST":
                    this.currentX = this.currentX + 1;
                    break;
                case "NORTH":
                    this.currentY = this.currentY - 1;
                    break;
                case "WEST":
                    this.currentX = this.currentX - 1;
                    break;
            }

            if (this.logs.Exists(obj => obj.x == this.currentX && obj.y == this.currentY ? true : false))
                this.loopCount++;

            log.x = this.currentX;
            log.y = this.currentY;

            logs.Add(log);

        }
        public bool CheckWayIsOKToMove(string dir)
        {
            switch(dir)
            {
                case "SOUTH":
                    if (env.GetPosInfo(this.currentX, this.currentY + 1) != "#" &&
                        env.GetPosInfo(this.currentX, this.currentY + 1) != "X"){
                        //also need to check if this pos is already in the log now ?
                        if (checkPassed(this.currentX, this.currentY + 1,"SOUTH") == false)
                            return true;
                        else 
                            return false;
                    }
                    else
                    {
                        if (env.GetPosInfo(this.currentX, this.currentY + 1) == "#")
                        {
                            return false;
                        }
                        else if (env.GetPosInfo(this.currentX, this.currentY + 1) == "X" && this.beast == true)
                        {
                            env.UpdatePosInfo(this.currentX, this.currentY + 1, " ");
                            return true;
                        }//if
                        else
                            return false;
                    }   
                        
                case "EAST":
                    if (env.GetPosInfo(this.currentX+1, this.currentY ) != "#" &&
                        env.GetPosInfo(this.currentX+1, this.currentY) != "X"){
                        if (checkPassed(this.currentX + 1, this.currentY,"EAST") == false)
                            return true;
                        else
                            return false;
                    }
                    else{
                        if (env.GetPosInfo(this.currentX+1, this.currentY ) == "#")
                        {
                            return false;
                        }
                        else if (env.GetPosInfo(this.currentX+1, this.currentY ) == "X" && this.beast == true)
                        {
                            env.UpdatePosInfo(this.currentX+1, this.currentY , " ");
                            return true;
                        }//if
                        else
                            return false;
                    }
                        
                case "NORTH":
                    if (env.GetPosInfo(this.currentX , this.currentY-1) != "#" &&
                        env.GetPosInfo(this.currentX , this.currentY-1) != "X"){
                        if (checkPassed(this.currentX, this.currentY - 1,"NORTH") == false)
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        if (env.GetPosInfo(this.currentX, this.currentY - 1) == "#")
                        {
                            return false;
                        }
                        else if (env.GetPosInfo(this.currentX, this.currentY - 1) == "X" && this.beast == true)
                        {
                            env.UpdatePosInfo(this.currentX, this.currentY - 1, " ");
                            return true;
                        }//if
                        else
                            return false;
                    }   
                case "WEST":
                    if (env.GetPosInfo(this.currentX-1, this.currentY) != "#" &&
                        env.GetPosInfo(this.currentX-1, this.currentY) != "X"){
                        if (checkPassed(this.currentX - 1, this.currentY,"WEST") == false)
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        if (env.GetPosInfo(this.currentX-1, this.currentY ) == "#")
                        {
                            return false;
                        }
                        else if (env.GetPosInfo(this.currentX-1, this.currentY) == "X" && this.beast == true)
                        {
                            env.UpdatePosInfo(this.currentX-1, this.currentY , " ");
                            return true;
                        }//if
                        else
                            return false;
                    }   
            }

            return false;

        }

        private bool checkPassed(int x, int y,string action)
        {
            //return this.logs.Exists(log => log.x == x && log.y == y  && log.move == action ? true : false);
            return false;
        }
    }
}
