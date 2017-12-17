using NUnit.Framework;
using System;
namespace TelephoneNumb
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestCase01()
        {
            ContactManager mgr = new ContactManager();
            mgr.ResetNodeCounts();
            mgr.AddContacts("0467123456");
            Assert.AreEqual(10,mgr.CountNodes());
        }
        [Test()]
        public void TestCase02()
        {
            ContactManager mgr = new ContactManager();
            mgr.ResetNodeCounts();
            mgr.AddContacts("0123456789");
            mgr.AddContacts("1123456789");
            Assert.AreEqual(20, mgr.CountNodes());
        }
        [Test()]
        public void TestCase03()
        {
            ContactManager mgr = new ContactManager();
            mgr.ResetNodeCounts();
            mgr.AddContacts("0123456789");
            mgr.AddContacts("0123");
            Assert.AreEqual(10, mgr.CountNodes());
        }
        [Test()]
        public void TestCase04()
        {
            ContactManager mgr = new ContactManager();
            mgr.ResetNodeCounts();
            mgr.AddContacts("0412578440");
            mgr.AddContacts("0412199803");
            mgr.AddContacts("0468892011");
            mgr.AddContacts("112");
            mgr.AddContacts("15");
            Assert.AreEqual(28, mgr.CountNodes());
        }


    }
}
