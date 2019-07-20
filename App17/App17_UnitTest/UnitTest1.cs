using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hexagon.DataStructure;

namespace App17_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MyStack s = new MyStack(10);
            Assert.AreEqual (10 , s.Size);
        }

        [TestMethod]
        public void TestMethod2()
        {
            MyStack s = new MyStack(10);
            Assert.AreEqual(0,s.Top);
        }

        [TestMethod]
        public void TestMethod3()
        {
            MyStack s = new MyStack(10);
            s.Push(100);
            s.Push(200);
            s.Push(300);
            Assert.AreEqual(3,s.Top);
        }

        [TestMethod]
        public void TestMethod4()
        {
            MyStack s = new MyStack(10);
            s.Push(100);
            s.Push(200);
            s.Push(300);
            Assert.AreEqual(300, s.Pop());
            Assert.AreEqual(200, s.Pop());
            Assert.AreEqual(100, s.Pop());
        }
    }
}
