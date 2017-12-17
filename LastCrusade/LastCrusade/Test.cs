using NUnit.Framework;
using System;
namespace LastCrusade
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase()
        {
            /*
                Map
                     0  0  0  0  3  0  0  0  0,
                     0 12  2  2 10 12  2 13  0,
                    12 10  0  0  0 11  2  9  0,
                    11  2  2  2  2  2 13  3  0,
                     0 12  8  8  8 13  3  3  0,
                    12  4  5  1 10  3  3  3  0,
                     3  7  1  4 13  7  5  6 13,
                    11 10  3  7 10 11  4  8  4,
                     0 12  6 10 12  2  6 10  3,
                    12  1  2  2 10 12  8  8 10,
                     7 10  0  0  0  7  1  4  2,
                     3  0  0 12 13  7  9  3  0,
                    11  2  2  5  6  4  5 10  0,
                     0  0 12  5 13  3  3  0  0,
                     0  0 11 10  3 11 10  0  0,

                //Indy init pos 
                1 0 Top
            */
            string data = "0 0 0 0 3 0 0 0 0,0 12 2 2 10 12 2 13 0,12 10 0 0 0 11 2 9 0,11 2 2 2 2 2 13 3 0,0 12 8 8 8 13 3 3 0,12 4 5 1 10 3 3 3 0,3 7 1 4 13 7 5 6 13,11 10 3 7 10 11 4 8 4,0 12 6 10 12 2 6 10 3,12 1 2 2 10 12 8 8 10,7 10 0 0 0 7 1 4 2,3 0 0 12 13 7 9 3 0,11 2 2 5 6 4 5 10 0,0 0 12 5 13 3 3 0 0,0 0 11 10 3 11 10 0 0";
            string[] toks = data.Split(',');
            int x = 0;
            int y = 0;
            Brick[,] bricks = new Brick[9,15];

            for (int i = 0; i < toks.Length;i++)
            {
                string[] elements = toks[i].Split(' ');
                x = 0;
                foreach(string e in elements){
                    Brick b = new Brick();
                    b.SetType(int.Parse(e),x,y);
                    bricks[x,y] = b;
                    if (x - 1 >= 0) bricks[x - 1, y].LinkRight(b);
                    if (y - 1 >= 0) bricks[x , y-1].LinkDown(b);
                    x++;
                }
                y++;
            }
            //
            Brick previous = null;
            Brick current = bricks[4, 0];
            System.Console.WriteLine(current.ToString());
            for (var i = 0; i < 100;i++)
            {
                Brick next = current.GetNextBricks(previous);
                if(next == null)
                {
                    Console.WriteLine("Something Wrong");
                }
                previous = current;
                current = next;

                System.Console.WriteLine(current.ToString());
            }


        }
    }
}
