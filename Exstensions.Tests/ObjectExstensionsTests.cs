using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exstensions.Tests
{
    [TestClass]
    public class ObjectExstensionsTests
    {
        [TestMethod]
        public void IsNull()
        {
            object @null = null;
            var @notNull = new object();

            Assert.IsTrue(@null.IsNull());
            Assert.IsFalse(@notNull.IsNull());
        }

        [TestMethod]
        public void IsNotNull()
        {
            object @null = null;
            var @notNull = new object();

            Assert.IsFalse(@null.IsNotNull());
            Assert.IsTrue(@notNull.IsNotNull());
        }

        [TestMethod]
        public void IsBetweenExclusive()
        {
            // [1, 4] => 2,3
            Assert.IsFalse(0.IsBetweenExclusive(1, 4));
            Assert.IsFalse(1.IsBetweenExclusive(1, 4));
            Assert.IsTrue(2.IsBetweenExclusive(1, 4));
            Assert.IsTrue(3.IsBetweenExclusive(1, 4));
            Assert.IsFalse(4.IsBetweenExclusive(1, 4));
            Assert.IsFalse(5.IsBetweenExclusive(1, 4));
        }

        [TestMethod]
        public void IsBetweenInclusive()
        {
            // (1, 4) => 1,2,3,4
            Assert.IsFalse(0.IsBetweenInclusive(1, 4));
            Assert.IsTrue(1.IsBetweenInclusive(1, 4));
            Assert.IsTrue(2.IsBetweenInclusive(1, 4));
            Assert.IsTrue(3.IsBetweenInclusive(1, 4));
            Assert.IsTrue(4.IsBetweenInclusive(1, 4));
            Assert.IsFalse(5.IsBetweenInclusive(1, 4));
        }

        [TestMethod]
        public void IsIn()
        {
            Assert.IsTrue(1.IsIn(1, 2, 3));
            Assert.IsFalse(0.IsIn(1, 2, 3));
            Assert.IsTrue("test1".IsIn("test1", "test2", "test3"));
            Assert.IsFalse("test0".IsIn("test1", "test2", "test3"));
        }

        [TestMethod]
        public void DeepClone()
        {
            var obj = new TestClass1()
            {
                IntProp = 1,
                StringProp = "a",
                ObjProp = new TestClass2
                {
                    IntProp = 2,
                    StringProp = "b"
                }
            };

            obj.SetPrivateIntProp(10);



            var clonedObj = obj.DeepClone();

            Assert.IsFalse(obj == clonedObj);
            Assert.IsFalse(obj.Equals(clonedObj));
            Assert.IsFalse(obj.GetHashCode() == clonedObj.GetHashCode());

            Assert.AreEqual(obj.IntProp, clonedObj.IntProp);
            Assert.AreEqual(obj.GetPrivateIntProp(), clonedObj.GetPrivateIntProp());
            Assert.AreEqual(obj.StringProp, clonedObj.StringProp);
            Assert.AreEqual(obj.ObjProp.IntProp, clonedObj.ObjProp.IntProp);
            Assert.AreEqual(obj.ObjProp.StringProp, clonedObj.ObjProp.StringProp);

        }
    }

    [Serializable()]
    class TestClass1
    {
        public int IntProp { get; set; }
        public string StringProp { get; set; }
        public TestClass2 ObjProp { get; set; }

        private int IntPropPrivate { get; set; }

        public int GetPrivateIntProp()
        {
            return IntPropPrivate;
        }

        public void SetPrivateIntProp(int value)
        {
            IntPropPrivate = value;
        }
    }

    [Serializable()]
    class TestClass2
    {
        public int IntProp { get; set; }
        public string StringProp { get; set; }
    }
}
