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
        public void IsBetweenExclusive()
        {
            // [1, 4] => 2,3
            Assert.IsFalse(0.IsBetweenExclusive(1,4));
            Assert.IsFalse(1.IsBetweenExclusive(1,4));
            Assert.IsTrue(2.IsBetweenExclusive(1,4));
            Assert.IsTrue(3.IsBetweenExclusive(1,4));
            Assert.IsFalse(4.IsBetweenExclusive(1,4));
            Assert.IsFalse(5.IsBetweenExclusive(1,4));
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
    }
}
