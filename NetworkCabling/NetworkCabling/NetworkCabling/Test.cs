using NUnit.Framework;
using System;
using System.Collections.Generic;
namespace NetworkCabling
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase()
        {
            var dir = System.Environment.CurrentDirectory;
            string testcase = "testcase6.txt";
            string url = dir + "/../../" + testcase;
            long result = 0;
            List<string> inputs = new List<string>();
            if (System.IO.File.Exists(url))
            {
                string[] lines = System.IO.File.ReadAllLines(url);
                int section = 0;//0:uninit 1:

                foreach(string data in lines)
                {
                    if (data== "Data:")
                    {
                        section = 1;
                    }
                    else if (data == "Answer:")
                    {
                        section = 2;
                    }
                    else{
                        if(section ==1)
                        {
                            inputs.Add(data);
                        }
                        else
                        {
                            result = long.Parse(data);
                        }
                    }
                }

            }

            //
            HouseMap houses = new HouseMap();
            foreach(string data in inputs)
            {
                string[] tok = data.Split(' ');
                houses.Add(long.Parse(tok[0]), long.Parse(tok[1]));
            }

            //Assert.AreEqual(result, houses.CalLength());
            long actual_result = houses.getMainCableLength() + houses.getHouseToMainCableLength();
            Assert.AreEqual(result, actual_result);

        }
    }
}
