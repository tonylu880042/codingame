using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace LastCrusade
{
    public class Brick
    {
        private int type;
        private int x;
        private int y;
        public const int TOP = 0;
        public const int DOWN = 1;
        public const int LEFT = 2;
        public const int RIGHT = 3;

        public Brick TopBrick = null;
        public Brick DownBrick = null;
        public Brick LeftBrick = null;
        public Brick RightBrick = null;

        public void SetType(int type,int x, int y)
        {
            this.type = type;
            this.x = x;
            this.y = y;
        }
        public int GetBrickType()
        {
            return this.type;
        }
        private int CalDir(Brick previousBrick)
        {
            if(previousBrick != null)
            {
                if (previousBrick.DownBrick == this)
                    return TOP;
                if (previousBrick.LeftBrick == this)
                    return RIGHT;
                if (previousBrick.RightBrick == this)
                    return LEFT;                
            }
            else{
                switch(this.type)
                {
                    case 1:                        
                    case 3:
                    case 7:
                    case 9:
                        return DOWN;
                    case 4:
                    case 10:
                        return LEFT;
                    case 5:
                    case 11:
                        return RIGHT;                    
                }//
            }
            return DOWN;

        }
        private Brick GetNextBricksType1(Brick previousBrick)
        {
            return this.DownBrick;    
        }
        private Brick GetNextBricksType2(Brick previousBrick)
        {
            var dir = CalDir(previousBrick);
            switch(dir)
            {
                case LEFT:
                    return this.RightBrick;
                case RIGHT:
                    return this.LeftBrick;
            }
            return null;
        }
        private Brick GetNextBricksType3(Brick previousBrick)
        {
            return this.DownBrick;
        }
        private Brick GetNextBricksType4(Brick previousBrick)
        {
            var dir = CalDir(previousBrick);
            if(dir == TOP)
                return this.LeftBrick;
            if (dir == RIGHT)
                return this.DownBrick;
            return null;
        }
        private Brick GetNextBricksType5(Brick previousBrick)
        {
            var dir = CalDir(previousBrick);
            if (dir == TOP)
                return this.RightBrick;
            if (dir == LEFT)
                return this.DownBrick;
            return null;
        }
        private Brick GetNextBricksType6(Brick previousBrick)
        {
            var dir = CalDir(previousBrick);
            if (dir == RIGHT)
                return this.LeftBrick;
            if (dir == LEFT)
                return this.RightBrick;
            return null;
        }
        private Brick GetNextBricksType7(Brick previousBrick)
        {            
            return this.DownBrick;
        }
        private Brick GetNextBricksType8(Brick previousBrick)
        {
            return this.DownBrick;
        }
        private Brick GetNextBricksType9(Brick previousBrick)
        {
            return this.DownBrick;
        }
        private Brick GetNextBricksType10(Brick previousBrick)
        {
            return this.LeftBrick;
        }
        private Brick GetNextBricksType11(Brick previousBrick)
        {
            return this.RightBrick;
        }
        private Brick GetNextBricksType12(Brick previousBrick)
        {
            return this.DownBrick;
        }
        private Brick GetNextBricksType13(Brick previousBrick)
        {
            return this.DownBrick;
        }
        public Brick GetNextBricks(Brick previousBrick)
        {
            if (previousBrick == this)
                previousBrick = null;
            switch(this.type)
            {
                case 1:
                    return GetNextBricksType1(previousBrick);
                case 2:
                    return GetNextBricksType2(previousBrick);
                case 3:
                    return GetNextBricksType3(previousBrick);
                case 4:
                    return GetNextBricksType4(previousBrick);
                case 5:
                    return GetNextBricksType5(previousBrick);
                case 6:
                    return GetNextBricksType6(previousBrick);
                case 7:
                    return GetNextBricksType7(previousBrick);
                case 8:
                    return GetNextBricksType8(previousBrick);
                case 9:
                    return GetNextBricksType9(previousBrick);
                case 10:
                    return GetNextBricksType10(previousBrick);
                case 11:
                    return GetNextBricksType11(previousBrick);
                case 12:
                    return GetNextBricksType12(previousBrick);
                case 13:
                    return GetNextBricksType13(previousBrick);

            }
            return null;
        }
       
        public void LinkRight(Brick b)
        {
            switch( this.type)
            {
                case 1:
                    this.LinkRightType1(b);
                    break;
                case 2:
                    this.LinkRightType2(b);
                    break;
                case 3:
                    this.LinkRightType3(b);
                    break;
                case 4:
                    this.LinkRightType4(b);
                    break;
                case 5:
                    this.LinkRightType5(b);
                    break;
                case 6:
                    this.LinkRightType6(b);
                    break;
                case 7:
                    this.LinkRightType7(b);
                    break;
                case 8:
                    this.LinkRightType8(b);
                    break;
                case 9:
                    this.LinkRightType9(b);
                    break;
                case 10:
                    this.LinkRightType10(b);
                    break;
                case 11:
                    this.LinkRightType11(b);
                    break;
                case 12:
                    this.LinkRightType12(b);
                    break;
                case 13:
                    this.LinkRightType13(b);
                    break;
            }
        }
        public void LinkDown(Brick b)
        {
            switch (this.type)
            {
                case 1:
                    this.LinkDownType1(b);
                    break;
                case 2:
                    this.LinkDownType2(b);
                    break;
                case 3:
                    this.LinkDownType3(b);
                    break;
                case 4:
                    this.LinkDownType4(b);
                    break;
                case 5:
                    this.LinkDownType5(b);
                    break;
                case 6:
                    this.LinkDownType6(b);
                    break;
                case 7:
                    this.LinkDownType7(b);
                    break;
                case 8:
                    this.LinkDownType8(b);
                    break;
                case 9:
                    this.LinkDownType9(b);
                    break;
                case 10:
                    this.LinkDownType10(b);
                    break;
                case 11:
                    this.LinkDownType11(b);
                    break;
                case 12:
                    this.LinkDownType12(b);
                    break;
                case 13:
                    this.LinkDownType13(b);
                    break;
            }
        }
        private void LinkRightType1(Brick b)
        {

            var t = (b.GetBrickType());
            if(t==2 || t==4 || t==6 || t==10)
            {
                b.LeftBrick = this;                    
            }
        }
        private void LinkRightType2(Brick b)
        {

            var t = (b.GetBrickType());
            if (t == 1 || t == 2 || t == 5 || t == 6 || t==8 || t == 9 || t == 13)
            {
                this.RightBrick = b;
            }
            if (t == 2 || t == 4 || t == 6 || t == 10)
                b.LeftBrick = this;
        }
        private void LinkRightType3(Brick b)
        {
            //none
        }
        private void LinkRightType4(Brick b)
        {            
            var t = (b.GetBrickType());
            if (t == 2 || t == 4 || t == 6 || t == 10)
                b.LeftBrick = this;
        }
        private void LinkRightType5(Brick b)
        {
            var t = (b.GetBrickType());
            if (t == 1 || t == 2 || t == 5 || t == 6 || t == 8 || t == 9|| t == 13)
            {
                this.RightBrick = b;
            }

        }
        private void LinkRightType6(Brick b)
        {
            var t = (b.GetBrickType());
            if (t == 1 || t == 2 || t == 5 || t == 6 || t == 8 || t == 9 || t == 13)
            {
                this.RightBrick = b;
            }

            if (t == 2 || t == 4 || t == 6 || t == 10)
                b.LeftBrick = this;
        }

        private void LinkRightType7(Brick b)
        {
            var t = (b.GetBrickType());
           
            if (t == 2 || t == 4 || t == 6 || t == 10)
                b.LeftBrick = this;
        }
        private void LinkRightType8(Brick b)
        {
            var t = (b.GetBrickType());

            if (t == 2 || t == 4 || t == 6 || t == 10)
                b.LeftBrick = this;
        }
        private void LinkRightType9(Brick b)
        {
           //none
        }
        private void LinkRightType10(Brick b)
        {
            //none
        }
        private void LinkRightType11(Brick b)
        {
            var t = (b.GetBrickType());
            if (t == 1 || t == 2 || t == 5 || t == 6 || t == 8 || t == 9 || t == 13)
            {
                this.RightBrick = b;
            }
        }
        private void LinkRightType12(Brick b)
        {
            var t = (b.GetBrickType());

            if (t == 2 || t == 4 || t == 6 || t == 10)
                b.LeftBrick = this;
        }
        private void LinkRightType13(Brick b)
        {
            //none
        }
        private void LinkDownType1(Brick b)
        {
            var t = (b.GetBrickType());
            if (t == 1 || t == 3 || t == 4 || t == 5 || t == 7 || t == 9 || t == 10 || t == 11)
            {
                this.DownBrick = b;
            }
        }
        private void LinkDownType2(Brick b)
        { //none
        }
        private void LinkDownType3(Brick b)
        { 
            var t = (b.GetBrickType());
            if (t == 1 || t == 3 || t == 4 || t == 5 || t == 7 || t == 9 || t == 10 || t == 11)
            {
                this.DownBrick = b;
            }
        }
        private void LinkDownType4(Brick b)
        {
            var t = (b.GetBrickType());
            if (t == 1 || t == 3 || t == 4 || t == 5 || t == 7 || t == 9 || t == 10 || t == 11)
            {
                this.DownBrick = b;
            }
        }
        private void LinkDownType5(Brick b)
        {
            var t = (b.GetBrickType());
            if (t == 1 || t == 3 || t == 4 || t == 5 || t == 7 || t == 9 || t == 10 || t == 11)
            {
                this.DownBrick = b;
            }
        }
        private void LinkDownType6(Brick b)
        {
            //none
        }
        private void LinkDownType7(Brick b)
        {
            var t = (b.GetBrickType());
            if (t == 1 || t == 3 || t == 4 || t == 5 || t == 7 || t == 9 || t == 10 || t == 11)
            {
                this.DownBrick = b;
            }
        }
        private void LinkDownType8(Brick b)
        {
            var t = (b.GetBrickType());
            if (t == 1 || t == 3 || t == 4 || t == 5 || t == 7 || t == 9 || t == 10 || t == 11)
            {
                this.DownBrick = b;
            }
        }
        private void LinkDownType9(Brick b)
        {
            var t = (b.GetBrickType());
            if (t == 1 || t == 3 || t == 4 || t == 5 || t == 7 || t == 9 || t == 10 || t == 11)
            {
                this.DownBrick = b;
            }
        }
        private void LinkDownType10(Brick b)
        {
            //none
        }
        private void LinkDownType11(Brick b)
        {
            //none
        }
        private void LinkDownType12(Brick b)
        {
            var t = (b.GetBrickType());
            if (t == 1 || t == 3 || t == 4 || t == 5 || t == 7 || t == 9 || t == 10 || t == 11)
            {
                this.DownBrick = b;
            }
        }
        private void LinkDownType13(Brick b)
        {
            var t = (b.GetBrickType());
            if (t == 1 || t == 3 || t == 4 || t == 5 || t == 7 || t == 9 || t == 10 || t == 11)
            {
                this.DownBrick = b;
            }
        }
        public Brick()
        {
            
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", this.x, this.y);
        }
        public Brick EnterFromPOS(string pos)
        {
            switch(this.type)
            {
                case 1:
                    return this.DownBrick;
                case 2:
                    if (pos == "LEFT")
                        return this.RightBrick;
                    else
                        return this.LeftBrick;
                case 3:
                    return this.DownBrick;
                case 4:
                    if (pos == "TOP")
                        return this.LeftBrick;
                    else
                        return this.DownBrick;
                case 5:
                    if (pos == "TOP")
                        return this.RightBrick;
                    else
                        return this.DownBrick;
                case 6:
                    if (pos == "LEFT")
                        return this.RightBrick;
                    else
                        return this.LeftBrick;
                case 7:
                case 8:
                case 9:
                case 12:
                case 13:    
                    return this.DownBrick;
                case 10:
                    return this.LeftBrick;
                case 11:
                    return this.RightBrick;              
            }
            return null;
        }

    }
}
