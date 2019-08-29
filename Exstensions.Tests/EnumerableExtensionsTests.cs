using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exstensions.Tests
{
    [TestClass]
    public class EnumerableExtensionsTests
    {
        [TestMethod]
        public void IsNullOrEmpty()
        {
            IEnumerable<string> nullDataset = null;
            IEnumerable<string> emptyDataset = new List<string>();
            IEnumerable<string> notEmptyDataset = new List<string> { "Fizz" };

            bool nullDatasetResult = nullDataset.IsNullOrEmpty(); // return true;
            bool emptyDatasetResult = emptyDataset.IsNullOrEmpty(); // return true;
            bool notEmptyDatasetResult = notEmptyDataset.IsNullOrEmpty(); // return false;

            Assert.IsTrue(nullDatasetResult);
            Assert.IsTrue(emptyDatasetResult);
            Assert.IsFalse(notEmptyDatasetResult);
        }
    }
}
