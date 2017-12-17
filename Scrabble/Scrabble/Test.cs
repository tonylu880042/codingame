using NUnit.Framework;
using System;
namespace Scrabble
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase01()
        {
            ScrabbleDict s = new ScrabbleDict();
            s.AddWord("because");
            s.AddWord("first");
            s.AddWord("these");
            s.AddWord("could");
            s.AddWord("which");
            s.SetupLimits("hicquwh");
            Assert.AreEqual("which",s.GetHighestScoreWord());
        }
        [Test()]
        public void TestCase02()
        {
            ScrabbleDict s = new ScrabbleDict();
            s.AddWord("some");
            s.AddWord("first");
            s.AddWord("potsie");
            s.AddWord("day");
            s.AddWord("could");
            s.AddWord("postie");
            s.AddWord("from");
            s.AddWord("have");
            s.AddWord("back");
            s.AddWord("this");
            s.SetupLimits("sopitez");
            Assert.AreEqual("potsie", s.GetHighestScoreWord());

        }
        [Test()]
        public void TestCase03()
        {
            ScrabbleDict s = new ScrabbleDict();
            s.AddWord("after");
            s.AddWord("repots");
            s.AddWord("user");
            s.AddWord("powers");
            s.AddWord("these");
            s.AddWord("time");
            s.AddWord("know");
            s.AddWord("from");
            s.AddWord("could");
            s.AddWord("people");
            s.SetupLimits("tsropwe");
            Assert.AreEqual("powers", s.GetHighestScoreWord());
        }
        [Test()]
        public void TestCase04()
        {
            ScrabbleDict s = new ScrabbleDict();
            s.AddWord("arrest");
            s.AddWord("rarest");
            s.AddWord("raster");
            s.AddWord("raters");
            s.AddWord("sartre");
            s.AddWord("starer");
            s.AddWord("waster");
            s.AddWord("waters");
            s.AddWord("wrest");
            s.AddWord("wrase");
            s.SetupLimits("arwtsre");
            Assert.AreEqual("waster", s.GetHighestScoreWord());
        }
        [Test()]
        public void TestCase05()
        {
            ScrabbleDict s = new ScrabbleDict();
            s.AddWord("entire");
            s.AddWord("tween");
            s.AddWord("soft");
            s.AddWord("would");
            s.AddWord("test");
            s.SetupLimits("etiewrn");
            Assert.AreEqual("tween", s.GetHighestScoreWord());
        }
        [Test()]
        public void TestCase06()
        {
            ScrabbleDict s = new ScrabbleDict();
            s.AddWord("qzyoq");
            s.AddWord("azejuy");
            s.AddWord("kqjsdh");
            s.AddWord("aeiou");
            s.AddWord("qsjkdh");
            s.SetupLimits("qzaeiou");
            Assert.AreEqual("aeiou", s.GetHighestScoreWord());

        }
        [Test()]
        public void TestCase07()
        {
            //ScrabbleDict s = new ScrabbleDict();
            //s.SetupLimits("etiewrn");
            //Assert.AreEqual("tween", s.GetHighestScoreWord());

        }
        [Test()]
        public void TestCase08()
        {
            ScrabbleDict s = new ScrabbleDict();
            var dir = System.Environment.CurrentDirectory;
            string testcase = "testcase8.txt";
            string url = dir + "/../../" + testcase;
            if (System.IO.File.Exists(url))
            {
                string[] lines = System.IO.File.ReadAllLines(url);
                foreach (string data in lines)
                {
                    s.AddWord(data);
                }
            }

            s.SetupLimits("retpasn");
            Assert.AreEqual("pastern", s.GetHighestScoreWord());

        }
    }
}
