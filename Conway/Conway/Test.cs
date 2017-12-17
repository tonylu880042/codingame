using NUnit.Framework;
using System;
namespace Conway
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void Test01Case()
        {
            ConwayGenerator gen = new ConwayGenerator();
            string result = gen.Generator(1,11);
            //Console.WriteLine(result);
            Assert.AreEqual("1 1 1 3 1 2 2 1 1 3 3 1 1 2 1 3 2 1 1 3 2 1 2 2 2 1",result);
        }
        [Test()]
        public void Test02Case()
        {
            ConwayGenerator gen = new ConwayGenerator();
            string result = gen.Generator(2, 1);
            //Console.WriteLine(result);
            Assert.AreEqual("2", result);
        }
        [Test()]
        public void Test03Case()
        {
            ConwayGenerator gen = new ConwayGenerator();
            string result = gen.Generator(5, 10);
            //Console.WriteLine(result);
            Assert.AreEqual("3 1 1 3 1 1 2 2 2 1 1 3 1 1 1 2 3 1 1 3 3 2 2 1 1 5", result);
        }
        [Test()]
        public void Test04Case()
        {
            ConwayGenerator gen = new ConwayGenerator();
            string result = gen.Generator(25, 10);
            //Console.WriteLine(result);
            Assert.AreEqual("3 1 1 3 1 1 2 2 2 1 1 3 1 1 1 2 3 1 1 3 3 2 2 1 1 25", result);
        }
        [Test()]
        public void Test05Case()
        {
            ConwayGenerator gen = new ConwayGenerator();
            string result = gen.Generator(1, 25);
            //Console.WriteLine(result);
            Assert.AreEqual("1 3 2 1 1 3 2 1 3 2 2 1 1 3 3 1 1 2 1 3 2 1 2 3 1 2 3 1 1 2 1 1 1 3 1 1 2 2 2 1 1 2 1 3 2 1 1 3 3 1 1 2 1 3 2 1 1 2 3 1 2 3 2 1 1 2 3 1 1 3 1 1 2 2 2 1 1 2 1 1 1 3 1 2 2 1 1 3 1 1 1 2 3 1 1 3 3 2 2 1 1 2 1 3 2 1 1 3 2 1 2 2 3 1 1 2 1 1 1 3 1 1 2 2 2 1 1 2 1 3 2 1 1 3 2 1 3 2 2 1 1 2 3 1 2 3 2 1 1 2 3 1 1 3 2 1 3 2 2 1 1 2 3 1 1 3 1 1 2 2 2 1 1 3 1 1 1 2 3 1 1 3 3 2 2 1 1 2 1 1 1 3 1 2 2 1 1 3 1 2 1 1 1 3 2 2 1 1 1 2 1 3 1 2 2 1 1 2 3 1 1 3 1 1 1 2 3 1 1 2 1 1 2 3 2 2 2 1 1 2 1 3 2 1 1 3 2 1 3 2 2 1 1 3 3 1 1 2 1 3 2 1 2 3 1 2 3 1 1 2 1 1 1 3 1 2 1 1 1 3 1 2 2 1 2 2 3 1 1 3 1 1 2 2 2 1 1 3 1 1 1 2 3 1 1 3 3 2 2 1 1 2 1 1 1 3 1 2 2 1 1 3 1 2 1 1 1 3 2 2 1 1 1 2 1 3 1 2 2 1 1 2 3 1 1 3 1 1 1 2 3 1 1 2 1 1 2 3 2 2 2 1 1 2 1 1 1 3 1 2 2 1 1 3 1 2 1 1 1 3 2 2 2 1 2 3 2 1 1 2 1 1 1 3 1 2 1 1 1 2 1 3 1 1 1 2 1 3 2 1 1 2 3 1 1 3 2 1 3 2 2 1 1 2 1 1 1 3 1 2 2 1 2 3 2 1 1 2 1 1 1 3 1 2 2 1 2 2 2 1 1 2 1 1 2 3 2 2 2 1 1 2 1 3 2 1 1 3 2 1 3 2 2 1 1 3 3 1 1 2 1 3 2 1 2 3 1 2 3 1 1 2 1 1 1 3 1 1 2 2 2 1 1 2 1 3 2 1 1 3 2 1 3 2 2 1 1 3 2 2 1 3 2 1 1 3 2 1 3 2 2 1 1 2 3 1 1 3 1 1 2 2 2 1 1 3 3 1 1 2 1 3 2 1 2 3 2 2 2 1 1 2 1 1 1 3 1 2 2 1 1 3 1 2 1 1 2 2 1 3 2 1 1 2 3 1 1 3 2 1 3 2 2 1 1 2 1 1 1 3 1 2 2 1 1 3 1 2 1 1 3 2 2 1 1 3 3 2 1 1 3 2 2 1 1 2 2 1 1 2 1 3 3 2 2 1 1 2 3 1 1 3 1 1 2 2 2 1 1 3 1 1 1 2 3 1 1 3 3 2 1 1 1 2 1 3 1 2 2 1 1 2 3 1 1 3 1 1 1 2 3 1 1 2 1 1 1 3 3 1 1 2 1 1 1 3 1 2 2 1 1 2 1 3 2 1 1 3 1 2 1 1 1 3 2 2 2 1 1 2 3 1 1 3 1 1 2 2 1 1 1 2 1 3 1 2 2 1 1 2 3 1 1 3 1 1 2 2 2 1 1 2 1 1 1 3 3 1 1 2 1 1 1 3 1 1 2 2 2 1 1 2 1 1 1 3 1 2 2 1 1 3 1 2 1 1 1 3 2 2 2 1 1 2 1 3 2 1 1 3 2 1 3 2 2 1 2 3 2 1 1 2 1 1 1 3 1 2 1 1 1 2 1 3 3 2 2 1 1 2 3 1 1 3 1 1 2 2 2 1 1 3 1 1 1 2 2 1 2 2 1 1 1 3 1 2 2 1 1 2 1 3 2 1 1 3 1 2 1 1 1 3 2 2 2 1 1 2 3 1 1 3 1 1 2 2 2 1 1 3 1 1 1 2 3 1 1 3 3 2 2 1 1 2 1 1 1 3 3 1 1 2 1 1 1 3 1 1 2 2 2 1 1 2 1 1 1 3 1 2 2 1 1 3 1 1 1 2 3 1 1 3 3 2 2 1 1 2 1 1 1 3 1 2 2 1 1 3 1 2 1 1 1 3 2 2 2 1 2 3 2 1 1 2 1 1 1 3 1 2 1 1 1 2 1 3 3 2 2 1 1 2 1 3 2 1 1 3 2 1 3 2 2 1 1 3 3 1 1 2 1 3 2 1 2 3 1 2 3 1 1 2 1 1 1 3 1 1 2 2 2 1 1 2 1 3 2 1 1 3 2 1 2 2 3 1 1 2 1 1 1 3 1 1 2 2 2 1 1 2 1 1 1 3 1 2 2 1 1 3 1 2 1 1 3 2 2 1 1 3 3 2 2 1 1 2 1 1 1 3 1 2 2 1 1 3 2 2 1 3 2 1 1 3 2 1 3 2 2 1 1 2 3 1 1 3 1 1 2 2 2 1 1 3 1 1 1 2 3 1 1 3 1 1 1 2 1 3 2 1 1 2 2 1 1 2 1 3 2 2 3 1 1 2 1 1 1 3 1 2 2 1 1 3 3 2 2 1 1 3 1 1 1 2 2 1 1 3 1 2 2 1", result);
        }
    }
}
