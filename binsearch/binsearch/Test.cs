using NUnit.Framework;
using System;
namespace binsearch
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase()
        {
            BinarySearch bs = new BinarySearch();

            bs.H = 100;
            bs.W = 100;

            bs.TargetX = 0;
            bs.TargetY = 0;

            bs.X0 = 5;
            bs.Y0 = 98;

            bs.Init();

            for (int i = 0; i < 100;i++)
            {
                
                if (bs.found() == false)
                {
                    string bombDir = bs.getHint(bs.mx,bs.my);
                    int[] result = bs.DoSearch(bombDir);
                    Console.WriteLine(string.Format("Round: {0},(x,y)=({1},{2}), Dir:{3}"
                                                    ,i+1,result[0],result[1],bombDir));
                }
                else
                {
                    Console.WriteLine("Found! Round=" + i.ToString());
                    break;
                }
            }
        }
    }
}
