using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Text;
namespace Maya
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase100()
        {
            List<int> dataSet = new List<int>();
            dataSet.Add(1);
            dataSet.Add(1);
            dataSet.Add(5);

            int result = 0;
            for (int i = dataSet.Count - 1; i >= 0; i--)
            {
                int d = dataSet[i];
                if (dataSet.Count - 1 - i == 0)
                {
                    result = result + d;
                }
                else
                {
                    int pow = 1;
                    for (int j = 0; j < dataSet.Count - 1 - i; j++)
                        pow = 20 * pow;
                    result = result + pow*d;
                }
            }
        }
        [Test()]
        public void TestCase00()
        {
            long result = 9740353140;

            List<long> answer = new List<long>();
            long quotient = result;

            if (quotient > 20)
            {
                while(quotient>20)
                {
                    answer.Add(quotient%20);
                    quotient = quotient / 20;
                }
                answer.Add(quotient % 20);
            }
            else
                answer.Add(result);
            long myAnswer = 0;
            for (int i = 0; i < answer.Count;i++)
            {
                if (i == 0)
                    myAnswer = answer[i];
                else{
                    long power = 1;
                    for (int j = 0; j < i; j++)
                        power = power * 20;
                    myAnswer = myAnswer + answer[i] * power;
                }
            }
            Assert.AreEqual(result, myAnswer );
        }
        [Test()]
        public void TestCase01()
        {
            MayaCal mc = new MayaCal(4,4);
            string line = ".oo.o...oo..ooo.oooo....o...oo..ooo.oooo....o...oo..ooo.oooo....o...oo..ooo.oooo";
            mc.Init(line);
            line = "o..o................____________________________________________________________";
            mc.Init(line);
            line = ".oo.....................................________________________________________";
            mc.Init(line);
            line = "............................................................____________________";
            mc.Init(line);

            //
            string[] d1 = new string[4];
            d1[0] = "o...";
            d1[1] = "....";
            d1[2] = "....";
            d1[3] = "....";
            MayaDigi md1 = mc.MakeMayaDigi(d1);
            md1.digi = mc.Recognize(md1);
            string[] d2 = new string[4];
            d2[0] = "o...";
            d2[1] = "....";
            d2[2] = "....";
            d2[3] = "....";
            MayaDigi md2 = mc.MakeMayaDigi(d2);
            md2.digi = mc.Recognize(md2);

            string op = "+";

            string[] result = mc.Caculate(md1, md2, op);
            StringBuilder answer = new StringBuilder();
            foreach (string d in result)
                answer.Append(d);
            StringBuilder sb = new StringBuilder();
            sb.Append("oo..").Append("....")
              .Append("....").Append("....");
            Assert.AreEqual(sb.ToString(),answer.ToString());
        }
        [Test()]
        public void TestCase02()
        {
            MayaCal mc = new MayaCal(4,4);
            string line = ".oo.o...oo..ooo.oooo....o...oo..ooo.oooo....o...oo..ooo.oooo....o...oo..ooo.oooo";
            mc.Init(line);
            line = "o..o................____________________________________________________________";
            mc.Init(line);
            line = ".oo.....................................________________________________________";
            mc.Init(line);
            line = "............................................................____________________";
            mc.Init(line);

            //

            string[] d1 = new string[4];
            d1[0] = "ooo.";
            d1[1] = "____";
            d1[2] = "____";
            d1[3] = "____";
            MayaDigi md1 = mc.MakeMayaDigi(d1);
            md1.digi = mc.Recognize(md1);

            string[] d2 = new string[4];
            d2[0] = "ooo.";
            d2[1] = "....";
            d2[2] = "....";
            d2[3] = "....";
            MayaDigi md2 = mc.MakeMayaDigi(d2);
            md2.digi = mc.Recognize(md2);

            string op = "+";

            string[] result = mc.Caculate(md1, md2, op);
            StringBuilder answer = new StringBuilder();
            foreach (string d in result)
                answer.Append(d);

            StringBuilder sb = new StringBuilder();
            sb.Append("o...").Append("....")
              .Append("....").Append("....");
            sb.Append("o...").Append("....")
              .Append("....").Append("....");
            Assert.AreEqual(sb.ToString(), answer.ToString());
        }
        [Test()]
        public void TestCase03()
        {
            MayaCal mc = new MayaCal(4, 4);
            string line = ".oo.o...oo..ooo.oooo....o...oo..ooo.oooo....o...oo..ooo.oooo....o...oo..ooo.oooo";
            mc.Init(line);
            line = "o..o................____________________________________________________________";
            mc.Init(line);
            line = ".oo.....................................________________________________________";
            mc.Init(line);
            line = "............................................................____________________";
            mc.Init(line);

            string[] d1 = new string[4];
            d1[0] = "....";
            d1[1] = "____";
            d1[2] = "....";
            d1[3] = "....";
            MayaDigi md1 = mc.MakeMayaDigi(d1);
            md1.digi = mc.Recognize(md1);

            string[] d2 = new string[4];
            d2[0] = "....";
            d2[1] = "____";
            d2[2] = "....";
            d2[3] = "....";
            MayaDigi md2 = mc.MakeMayaDigi(d2);
            md2.digi = mc.Recognize(md2);

            string op = "*";

            string[] result = mc.Caculate(md1, md2, op);
            StringBuilder answer = new StringBuilder();
            foreach (string d in result)
                answer.Append(d);

            StringBuilder sb = new StringBuilder();
            sb.Append("o...").Append("....")
              .Append("....").Append("....");
            sb.Append("....").Append("____")
              .Append("....").Append("....");
            Assert.AreEqual(sb.ToString(), answer.ToString());

        }
        [Test()]
        public void TestCase04()
        {
            MayaCal mc = new MayaCal(4, 4);
            string line = ".oo.o...oo..ooo.oooo....o...oo..ooo.oooo....o...oo..ooo.oooo....o...oo..ooo.oooo";
            mc.Init(line);
            line = "o..o................____________________________________________________________";
            mc.Init(line);
            line = ".oo.....................................________________________________________";
            mc.Init(line);
            line = "............................................................____________________";
            mc.Init(line);

            string[] d1 = new string[4];
            d1[0] = "oo..";
            d1[1] = "____";
            d1[2] = "....";
            d1[3] = "....";
            MayaDigi md1 = mc.MakeMayaDigi(d1);
            md1.digi = mc.Recognize(md1);

            string[] d2 = new string[4];
            d2[0] = "oo..";
            d2[1] = "....";
            d2[2] = "....";
            d2[3] = "....";
            MayaDigi md2 = mc.MakeMayaDigi(d2);
            md2.digi = mc.Recognize(md2);

            string op = "-";

            string[] result = mc.Caculate(md1, md2, op);
            StringBuilder answer = new StringBuilder();
            foreach (string d in result)
                answer.Append(d);

            StringBuilder sb = new StringBuilder();
            sb.Append("....").Append("____")
              .Append("....").Append("....");
            
            //sb.Append("....").Append("____")
            //  .Append("....").Append("....");
            Assert.AreEqual(sb.ToString(), answer.ToString());
        }
        [Test()]
        public void TestCase05()
        {
            MayaCal mc = new MayaCal(4, 4);
            string line = ".oo.o...oo..ooo.oooo....o...oo..ooo.oooo....o...oo..ooo.oooo....o...oo..ooo.oooo";
            mc.Init(line);
            line = "o..o................____________________________________________________________";
            mc.Init(line);
            line = ".oo.....................................________________________________________";
            mc.Init(line);
            line = "............................................................____________________";
            mc.Init(line);

            string[] d1 = new string[8];
            d1[0] = "o...";
            d1[1] = "____";
            d1[2] = "....";
            d1[3] = "....";
            d1[4] = "ooo.";
            d1[5] = "....";
            d1[6] = "....";
            d1[7] = "....";
            MayaDigi md1 = mc.MakeMayaDigi(d1);
            md1.digi = mc.Recognize(md1);

            string[] d2 = new string[4];
            d2[0] = "oo..";
            d2[1] = "____";
            d2[2] = "....";
            d2[3] = "....";
            MayaDigi md2 = mc.MakeMayaDigi(d2);
            md2.digi = mc.Recognize(md2);

            string op = "-";

            string[] result = mc.Caculate(md1, md2, op);
            StringBuilder answer = new StringBuilder();
            foreach (string d in result)
                answer.Append(d);

            StringBuilder sb = new StringBuilder();

            sb.Append("....").Append("____")
              .Append("....").Append("....");

            sb.Append("o...").Append("____")
              .Append("____").Append("____");
            Assert.AreEqual(sb.ToString(), answer.ToString());
        }
        [Test()]
        public void TestCase06()
        {
            MayaCal mc = new MayaCal(4, 4);
            string line = ".oo.o...oo..ooo.oooo....o...oo..ooo.oooo....o...oo..ooo.oooo....o...oo..ooo.oooo";
            mc.Init(line);
            line = "o..o................____________________________________________________________";
            mc.Init(line);
            line = ".oo.....................................________________________________________";
            mc.Init(line);
            line = "............................................................____________________";
            mc.Init(line);

            string[] d1 = new string[4];
            d1[0] = "ooo.";
            d1[1] = "____";
            d1[2] = "....";
            d1[3] = "....";

            MayaDigi md1 = mc.MakeMayaDigi(d1);
            md1.digi = mc.Recognize(md1);

            string[] d2 = new string[4];
            d2[0] = "oooo";
            d2[1] = "....";
            d2[2] = "....";
            d2[3] = "....";
            MayaDigi md2 = mc.MakeMayaDigi(d2);
            md2.digi = mc.Recognize(md2);

            string op = "/";

            string[] result = mc.Caculate(md1, md2, op);
            StringBuilder answer = new StringBuilder();
            foreach (string d in result)
                answer.Append(d);

            StringBuilder sb = new StringBuilder();

            sb.Append("oo..").Append("....")
              .Append("....").Append("....");

            Assert.AreEqual(sb.ToString(), answer.ToString());

        }
        [Test()]
        public void TestCase07()
        {
            MayaCal mc = new MayaCal(4, 4);
            string line = ".oo.o...oo..ooo.oooo....o...oo..ooo.oooo....o...oo..ooo.oooo....o...oo..ooo.oooo";
            mc.Init(line);
            line = "o..o................____________________________________________________________";
            mc.Init(line);
            line = ".oo.....................................________________________________________";
            mc.Init(line);
            line = "............................................................____________________";
            mc.Init(line);

            string[] d1 = new string[12];
            d1[0] = "oooo";
            d1[1] = "....";
            d1[2] = "....";
            d1[3] = "....";

            d1[4] = "ooo.";
            d1[5] = "____";
            d1[6] = "....";
            d1[7] = "....";

            d1[8] = ".oo.";
            d1[9] = "o..o";
            d1[10] = ".oo.";
            d1[11] = "....";

            MayaDigi md1 = mc.MakeMayaDigi(d1);
            md1.digi = mc.Recognize(md1);

            string[] d2 = new string[4];

            d2[0] = "....";
            d2[1] = "____";
            d2[2] = "____";
            d2[3] = "....";
            MayaDigi md2 = mc.MakeMayaDigi(d2);
            md2.digi = mc.Recognize(md2);

            string op = "/";

            string[] result = mc.Caculate(md1, md2, op);
            StringBuilder answer = new StringBuilder();
            foreach (string d in result)
                answer.Append(d);

            StringBuilder sb = new StringBuilder();

            sb.Append("ooo.").Append("____")
              .Append("....").Append("....");
            sb.Append("o...").Append("____")
              .Append("____").Append("____");

            Assert.AreEqual(sb.ToString(), answer.ToString());
        }
        [Test()]
        public void TestCase08()
        {
            MayaCal mc = new MayaCal(4, 4);
            string line = ".oo.o...oo..ooo.oooo....o...oo..ooo.oooo....o...oo..ooo.oooo....o...oo..ooo.oooo";
            mc.Init(line);
            line = "o..o................____________________________________________________________";
            mc.Init(line);
            line = ".oo.....................................________________________________________";
            mc.Init(line);
            line = "............................................................____________________";
            mc.Init(line);

            string[] d1 = new string[16];
            d1[0] = "o...";
            d1[1] = "....";
            d1[2] = "....";
            d1[3] = "....";

            d1[4] = "....";
            d1[5] = "____";
            d1[6] = "____";
            d1[7] = "....";

            d1[8] = "oo..";
            d1[9] = "____";
            d1[10] = "____";
            d1[11] = "____";

            d1[12] = "....";
            d1[13] = "____";
            d1[14] = "....";
            d1[15] = "....";

            MayaDigi md1 = mc.MakeMayaDigi(d1);
            md1.digi = mc.Recognize(md1);

            string[] d2 = new string[20];

            d2[0] = "oooo";
            d2[1] = "....";
            d2[2] = "....";
            d2[3] = "....";

            d2[4] = "ooo.";
            d2[5] = "____";
            d2[6] = "____";
            d2[7] = "____";

            d2[8] = "oo..";
            d2[9] = "____";
            d2[10] = "____";
            d2[11] = "....";

            d2[12] = "....";
            d2[13] = "____";
            d2[14] = "____";
            d2[15] = "....";

            d2[16] = "oo..";
            d2[17] = "____";
            d2[18] = "____";
            d2[19] = "....";

            MayaDigi md2 = mc.MakeMayaDigi(d2);
            md2.digi = mc.Recognize(md2);

            string op = "*";

            string[] result = mc.Caculate(md1, md2, op);
            StringBuilder answer = new StringBuilder();
            foreach (string d in result)
                answer.Append(d);

            StringBuilder sb = new StringBuilder();

            sb.Append("oo..").Append("____").Append("....").Append("....");
            sb.Append("oo..").Append("____").Append("____").Append("....");
            sb.Append("ooo.").Append("....").Append("....").Append("....");

            sb.Append("oo..").Append("____").Append("____").Append("____");
            sb.Append("oooo").Append("....").Append("....").Append("....");
            sb.Append("oo..").Append("....").Append("....").Append("....");

            sb.Append("oo..").Append("____").Append("____").Append("____");
            sb.Append(".oo.").Append("o..o").Append(".oo.").Append("....");

            Assert.AreEqual(sb.ToString(), answer.ToString());
        }
        [Test()]
        public void TestCase09()
        {
            MayaCal mc = new MayaCal(4, 4);
            string line = ".oo.o...oo..ooo.oooo....o...oo..ooo.oooo....o...oo..ooo.oooo....o...oo..ooo.oooo";
            mc.Init(line);
            line = "o..o................____________________________________________________________";
            mc.Init(line);
            line = ".oo.....................................________________________________________";
            mc.Init(line);
            line = "............................................................____________________";
            mc.Init(line);

            string[] d1 = new string[16];

            d1[0] = "....";
            d1[1] = "____";
            d1[2] = "____";
            d1[3] = "____";

            d1[4] = "ooo.";
            d1[5] = "____";
            d1[6] = "....";
            d1[7] = "....";

            d1[8] = "oo..";
            d1[9] = "____";
            d1[10] = "____";
            d1[11] = "....";

            d1[12] = "o...";
            d1[13] = "____";
            d1[14] = "____";
            d1[15] = "____";


            MayaDigi md1 = mc.MakeMayaDigi(d1);
            md1.digi = mc.Recognize(md1);

            string[] d2 = new string[4];
            d2[0] = ".oo.";
            d2[1] = "o..o";
            d2[2] = ".oo.";
            d2[3] = "....";
            MayaDigi md2 = mc.MakeMayaDigi(d2);
            md2.digi = mc.Recognize(md2);

            string op = "*";

            string[] result = mc.Caculate(md1, md2, op);
            StringBuilder answer = new StringBuilder();
            foreach (string d in result)
                answer.Append(d);

            StringBuilder sb = new StringBuilder();

            sb.Append(".oo.").Append("o..o")
              .Append(".oo.").Append("....");

            Assert.AreEqual(sb.ToString(), answer.ToString());
        }
        [Test()]
        public void TestCase10()
        {
            MayaCal mc = new MayaCal(4, 4);
            string line = ".oo.o...oo..ooo.oooo....o...oo..ooo.oooo....o...oo..ooo.oooo....o...oo..ooo.oooo";
            mc.Init(line);
            line = "o..o................____________________________________________________________";
            mc.Init(line);
            line = ".oo.....................................________________________________________";
            mc.Init(line);
            line = "............................................................____________________";
            mc.Init(line);

            string[] d1 = new string[16];

            d1[0] = "o...";
            d1[1] = "....";
            d1[2] = "....";
            d1[3] = "....";

            d1[4] = ".oo.";
            d1[5] = "o..o";
            d1[6] = ".oo.";
            d1[7] = "....";

            d1[8] = ".oo.";
            d1[9] = "o..o";
            d1[10] = ".oo.";
            d1[11] = "....";

            d1[12] = "o...";
            d1[13] = "....";
            d1[14] = "....";
            d1[15] = "....";


            MayaDigi md1 = mc.MakeMayaDigi(d1);
            md1.digi = mc.Recognize(md1);

            string[] d2 = new string[8];
            d2[0] = "oo..";
            d2[1] = "....";
            d2[2] = "....";
            d2[3] = "....";

            d2[4] = "oo..";
            d2[5] = "....";
            d2[6] = "....";
            d2[7] = "....";

            MayaDigi md2 = mc.MakeMayaDigi(d2);
            md2.digi = mc.Recognize(md2);

            string op = "*";

            string[] result = mc.Caculate(md1, md2, op);
            StringBuilder answer = new StringBuilder();
            foreach (string d in result)
                answer.Append(d);

            StringBuilder sb = new StringBuilder();

            sb.Append("oo..").Append("....").Append("....").Append("....");
            sb.Append("oo..").Append("....").Append("....").Append("....");
            sb.Append(".oo.").Append("o..o").Append(".oo.").Append("....");
            sb.Append("oo..").Append("....").Append("....").Append("....");
            sb.Append("oo..").Append("....").Append("....").Append("....");

            Assert.AreEqual(sb.ToString(), answer.ToString());
        }
        [Test()]
        public void TestCase11()
        {
            MayaCal mc = new MayaCal(1, 1);
            string line = "0123456789ABCDEFGHIJ";
            mc.Init(line);
            string[] d1 = new string[4];
            d1[0] = "1";
            d1[1] = "0";
            d1[2] = "0";
            d1[3] = "G";
            MayaDigi md1 = mc.MakeMayaDigi(d1);
            md1.digi = mc.Recognize(md1);
            string[] d2 = new string[2];
            d2[0] = "2";
            d2[1] = "2";
            MayaDigi md2 = mc.MakeMayaDigi(d2);
            md2.digi = mc.Recognize(md2);

            string op = "*";
            string[] result = mc.Caculate(md1, md2, op);
            StringBuilder answer = new StringBuilder();
            foreach (string d in result)
                answer.Append(d);

            StringBuilder sb = new StringBuilder();

            sb.Append("2").Append("2").Append("1").Append("D").Append("C");
            Assert.AreEqual(sb.ToString(), answer.ToString());

        }
        [Test()]
        public void TestCase12()
        {
            MayaCal mc = new MayaCal(11, 11);
            string line = "....................................................................................................................................................................................XX........XX.XX....XX.XX.XX..XX.XX.XX.XX";
            mc.Init(line);
            line = ".............................................................................................................................XX........XX.XX....XX.XX.XX..XX.XX.XX.XXXXXXXXXXXXX....XX........XX.XX....XX.XX.XX..XX.XX.XX.XX";
            mc.Init(line);
            line = "....XXXX.....................................................................................................................XX........XX.XX....XX.XX.XX..XX.XX.XX.XXXXXXXXXXXXX............................................";
            mc.Init(line);
            line = "...X....X.............................................................XX........XX.XX....XX.XX.XX..XX.XX.XX.XXXXXXXXXXXXX.......................................................XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            mc.Init(line);
            line = "..X......X.....XX........XX.XX.....XX.XX.XX.XX.XX.XX.XXXXXXXXXXXXX....XX........XX.XX....XX.XX.XX..XX.XX.XX.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            mc.Init(line);
            line = ".X.X....X.X....XX........XX.XX.....XX.XX.XX.XX.XX.XX.XXXXXXXXXXXXX.......................................................XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX............................................";
            mc.Init(line);
            line = ".XXXXXXXXXX.......................................................XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.......................................................XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            mc.Init(line);
            line = ".X.X....X.X.......................................................XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.......................................................XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            mc.Init(line);
            line = "..X......X...............................................................................................................XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX............................................";
            mc.Init(line);
            line = "...X....X................................................................................................................XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            mc.Init(line);
            line = "....XXXX........................................................................................................................................................................XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            mc.Init(line);
            string[] d1 = new string[33];

            d1[0] = "...........";
            d1[1] = "...........";
            d1[2] = "...........";
            d1[3] = "...........";

            d1[4] = "XXXXXXXXXXX";
            d1[5] = "XXXXXXXXXXX";
            d1[6] = "...........";
            d1[7] = "...........";

            d1[8] = "...........";
            d1[9] = "...........";
            d1[10] = "...........";
            d1[11] = "...........";

            d1[12] = "...........";
            d1[13] = "....XXXX...";
            d1[14] = "...X....X..";
            d1[15] = "..X......X.";
            d1[16] = ".X.X....X.X";
            d1[17] = ".XXXXXXXXXX";
            d1[18] = ".X.X....X.X";
            d1[19] = "..X......X.";

            d1[20] = "...X....X..";
            d1[21] = "....XXXX...";
            d1[22] = "...........";
            d1[23] = "...XX.XX...";

            d1[24] = "...XX.XX...";
            d1[25] = "...........";
            d1[26] = "XXXXXXXXXXX";
            d1[27] = "XXXXXXXXXXX";

            d1[28] = "...........";
            d1[29] = "...........";
            d1[30] = "XXXXXXXXXXX";
            d1[31] = "XXXXXXXXXXX";
            d1[32] = "...........";
            MayaDigi md1 = mc.MakeMayaDigi(d1);
            md1.digi = mc.Recognize(md1);
            string[] d2 = new string[44];
            d2[0] = "...........";
            d2[1] = "...........";
            d2[2] = "...........";
            d2[3] = "...........";
            d2[4] = "...XX.XX...";
            d2[5] = "...XX.XX...";
            d2[6] = "...........";
            d2[7] = "...........";
            d2[8] = "...........";
            d2[9] = "...........";
            d2[10] = "...........";
            d2[11] = "...........";
            d2[12] = "...XX.XX...";
            d2[13] = "...XX.XX...";
            d2[14] = "...........";
            d2[15] = "XXXXXXXXXXX";
            d2[16] = "XXXXXXXXXXX";
            d2[17] = "...........";
            d2[18] = "...........";
            d2[19] = "XXXXXXXXXXX";
            d2[20] = "XXXXXXXXXXX";
            d2[21] = "...........";
            d2[22] = "....XX.....";
            d2[23] = "....XX.....";
            d2[24] = "...........";
            d2[25] = "XXXXXXXXXXX";
            d2[26] = "XXXXXXXXXXX";
            d2[27] = "...........";
            d2[28] = "XXXXXXXXXXX";
            d2[29] = "XXXXXXXXXXX";
            d2[30] = "...........";
            d2[31] = "XXXXXXXXXXX";
            d2[32] = "XXXXXXXXXXX";
            d2[33] = "...........";
            d2[34] = "...........";
            d2[35] = "....XXXX...";
            d2[36] = "...X....X..";
            d2[37] = "..X......X.";
            d2[38] = ".X.X....X.X";
            d2[39] = ".XXXXXXXXXX";
            d2[40] = ".X.X....X.X";
            d2[41] = "..X......X.";
            d2[42] = "...X....X..";
            d2[43] = "....XXXX...";
            MayaDigi md2 = mc.MakeMayaDigi(d2);
            md2.digi = mc.Recognize(md2);

            string op = "*";
            string[] result = mc.Caculate(md1, md2, op);
            StringBuilder answer = new StringBuilder();
            foreach (string d in result)
                answer.Append(d);

            StringBuilder sb = new StringBuilder();
            sb.Append("...........").Append(".XX.XX.XX..").
Append(".XX.XX.XX..").
Append("...........").
Append("XXXXXXXXXXX").
Append("XXXXXXXXXXX").
Append("...........").
Append("...........").
Append("XXXXXXXXXXX").
Append("XXXXXXXXXXX").
Append("...........").
Append("...........").
Append("...........").
Append("...........").
Append("...........").
Append("XXXXXXXXXXX").
Append("XXXXXXXXXXX").
Append("...........").
Append("...........").
Append("...........").
Append("...........").
Append("...........").
Append("...........").
Append("....XX.....").
Append("....XX.....").
Append("...........").
Append("XXXXXXXXXXX").
Append("XXXXXXXXXXX").
Append("...........").
Append("...........")
              .Append("XXXXXXXXXXX")
.Append("XXXXXXXXXXX")
.Append("...........")
.Append("...........")
.Append(".XX.XX.XX..")
.Append(".XX.XX.XX..")
.Append("...........")
.Append("XXXXXXXXXXX")
.Append("XXXXXXXXXXX")
.Append("...........")
.Append("...........")
.Append("XXXXXXXXXXX")
.Append("XXXXXXXXXXX")
.Append("...........")
.Append("...........")
.Append("...XX.XX...")
.Append("...XX.XX...")
.Append("...........")
.Append("XXXXXXXXXXX")
.Append("XXXXXXXXXXX")
.Append("...........")
.Append("...........")
.Append("XXXXXXXXXXX")
.Append("XXXXXXXXXXX")
.Append("...........")
.Append("...........")
.Append("...........")
.Append("....XXXX...")
.Append("...X....X..")
.Append("..X......X.")
.Append(".X.X....X.X")
.Append(".XXXXXXXXXX")
.Append(".X.X....X.X")
.Append("..X......X.")
.Append("...X....X..")
              .Append("....XXXX...");


            Assert.AreEqual(sb.ToString(), answer.ToString());
        }
    }
}
