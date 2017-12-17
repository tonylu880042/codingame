using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
namespace Gift
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase01()
        {
            /*
3
100
20
20
40
            */
            GiftInvest gi = new GiftInvest();
            gi.SetBudget(100);
            gi.AddOdds(20);
            gi.AddOdds(20);
            gi.AddOdds(40);
            StringBuilder sb = new StringBuilder();
            List<int> result = null;
            try
            {
                result = gi.Calculate();
                if (result != null)
                {
                    result.ForEach(x => sb.AppendLine(x.ToString()));
                }
            }
            catch (ImpossibleException e)
            {
                sb.Clear();
                sb.Append("IMPOSSIBLE");
            }

            Assert.AreEqual("IMPOSSIBLE", sb.ToString());
        }
        [Test()]
        public void TestCase02()
        {
            /*
3
100
40
40
40
            */
            GiftInvest gi = new GiftInvest();
            gi.SetBudget(100);
            gi.AddOdds(40);
            gi.AddOdds(40);
            gi.AddOdds(40);
            StringBuilder sb = new StringBuilder();
            List<int> result = null;
            try
            {
                result = gi.Calculate();
                if (result != null)
                {
                    result.ForEach(x => sb.AppendLine(x.ToString()));
                }
            }
            catch (ImpossibleException e)
            {
                sb.Clear();
                sb.Append("IMPOSSIBLE");
            }
            StringBuilder ans = new StringBuilder();
            ans.AppendLine("33");
            ans.AppendLine("33");
            ans.AppendLine("34");

            Assert.AreEqual(ans.ToString(), sb.ToString());
        }
        [Test()]
        public void TestCase03()
        {
            GiftInvest gi = new GiftInvest();
            gi.SetBudget(100);
            gi.AddOdds(100);
            gi.AddOdds(1);
            gi.AddOdds(60);
            StringBuilder sb = new StringBuilder();
            List<int> result = null;
            try
            {
                result = gi.Calculate();
                if (result != null)
                {
                    result.ForEach(x => sb.AppendLine(x.ToString()));
                }
            }
            catch (ImpossibleException e)
            {
                sb.Clear();
                sb.Append("IMPOSSIBLE");
            }
            StringBuilder ans = new StringBuilder();
            ans.AppendLine("1");
            ans.AppendLine("49");
            ans.AppendLine("50");

            Assert.AreEqual(ans.ToString(), sb.ToString());
        }
        [Test()]
        public void TestCase04()
        {
            /*
             3
            100
            20
            20
            20
            */

            GiftInvest gi = new GiftInvest();
            gi.SetBudget(100);
            gi.AddOdds(20);
            gi.AddOdds(20);
            gi.AddOdds(20);
            StringBuilder sb = new StringBuilder();
            List<int> result = null;
            try{
                result = gi.Calculate();
                if(result != null)
                {
                    result.ForEach(x => sb.AppendLine(x.ToString()));
                }
            }
            catch(ImpossibleException e)
            {
                sb.Clear();
                sb.Append("IMPOSSIBLE");
            }

            Assert.AreEqual("IMPOSSIBLE",sb.ToString());

        }
        [Test()]
        public void TestCase05()
        {
            GiftInvest gi = new GiftInvest();
            gi.SetBudget(3);
            gi.AddOdds(3);
            gi.AddOdds(3);
            gi.AddOdds(3);
            StringBuilder sb = new StringBuilder();
            List<int> result = null;
            try
            {
                result = gi.Calculate();
                if (result != null)
                {
                    result.ForEach(x => sb.AppendLine(x.ToString()));
                }
            }
            catch (ImpossibleException e)
            {
                sb.Clear();
                sb.Append("IMPOSSIBLE");
            }
            StringBuilder ans = new StringBuilder();
            ans.AppendLine("1");
            ans.AppendLine("1");
            ans.AppendLine("1");

            Assert.AreEqual(ans.ToString(), sb.ToString());
        }
        [Test()]
        public void TestCase06()
        {
            GiftInvest gi = new GiftInvest();
            gi.SetBudget(100);
            gi.AddOdds(10);
            gi.AddOdds(100);
            gi.AddOdds(100);
            StringBuilder sb = new StringBuilder();
            List<int> result = null;
            try
            {
                result = gi.Calculate();
                if (result != null)
                {
                    result.ForEach(x => sb.AppendLine(x.ToString()));
                }
            }
            catch (ImpossibleException e)
            {
                sb.Clear();
                sb.Append("IMPOSSIBLE");
            }
            StringBuilder ans = new StringBuilder();
            ans.AppendLine("10");
            ans.AppendLine("45");
            ans.AppendLine("45");

            Assert.AreEqual(ans.ToString(), sb.ToString());
        }
        [Test()]
        public void TestCase07()
        {
            GiftInvest gi = new GiftInvest();
            gi.SetBudget(10);
            gi.AddOdds(5);
            gi.AddOdds(10);
            gi.AddOdds(5);
            StringBuilder sb = new StringBuilder();
            List<int> result = null;
            try
            {
                result = gi.Calculate();
                if (result != null)
                {
                    result.ForEach(x => sb.AppendLine(x.ToString()));
                }
            }
            catch (ImpossibleException e)
            {
                sb.Clear();
                sb.Append("IMPOSSIBLE");
            }
            StringBuilder ans = new StringBuilder();
            ans.AppendLine("3");
            ans.AppendLine("3");
            ans.AppendLine("4");

            Assert.AreEqual(ans.ToString(), sb.ToString());
        }
        [Test()]
        public void TestCase08()
        {
            GiftInvest gi = new GiftInvest();
            gi.SetBudget(10);
            gi.AddOdds(4);
            gi.AddOdds(4);
            gi.AddOdds(4);
            StringBuilder sb = new StringBuilder();
            List<int> result = null;
            try
            {
                result = gi.Calculate();
                if (result != null)
                {
                    result.ForEach(x => sb.AppendLine(x.ToString()));
                }
            }
            catch (ImpossibleException e)
            {
                sb.Clear();
                sb.Append("IMPOSSIBLE");
            }
            StringBuilder ans = new StringBuilder();
            ans.AppendLine("3");
            ans.AppendLine("3");
            ans.AppendLine("4");

            Assert.AreEqual(ans.ToString(), sb.ToString());
        }
        [Test()]
        public void TestCase09()
        {
            var dir = System.Environment.CurrentDirectory;
            string testcase = "testcase9.txt";
            string url = dir + "/../../" + testcase;
            GiftInvest gi = new GiftInvest();
            gi.SetBudget(85614);
            if (System.IO.File.Exists(url))
            {
                string[] lines = System.IO.File.ReadAllLines(url);

                foreach (string data in lines)
                {
                    gi.AddOdds(int.Parse(data));
                }

            }
            else
            {
                return;
            }

            StringBuilder sb = new StringBuilder();
            List<int> result = null;
            try
            {
                result = gi.Calculate();
                if (result != null)
                {
                    result.ForEach(x => Console.WriteLine(x.ToString()));
                }
            }
            catch (ImpossibleException e)
            {
                sb.Clear();
                sb.Append("IMPOSSIBLE");
            }
            /*
            StringBuilder ans = new StringBuilder();
            ans.AppendLine("1");
            ans.AppendLine("1");
            ans.AppendLine("1");

            Assert.AreEqual(ans.ToString(), sb.ToString());
            */
        }
    }
}
