using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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


        [TestMethod]
        public void IsNotNullOrEmpty()
        {
            IEnumerable<string> nullDataset = null;
            IEnumerable<string> emptyDataset = new List<string>();
            IEnumerable<string> notEmptyDataset = new List<string> { "test" };

            bool nullDatasetResult = nullDataset.IsNotNullOrEmpty(); // return false;
            bool emptyDatasetResult = emptyDataset.IsNotNullOrEmpty(); // return false;
            bool notEmptyDatasetResult = notEmptyDataset.IsNotNullOrEmpty(); // return true;

            Assert.IsFalse(nullDatasetResult);
            Assert.IsFalse(emptyDatasetResult);
            Assert.IsTrue(notEmptyDatasetResult);
        }

        [TestMethod]
        public void ForEach()
        {
            var square = new Func<int, int>(x => x * x);

            int sum1 = 0;
            int sum2 = 0;

            IEnumerable<int> ints = new List<int> { 1, 2, 3, 4 }.AsEnumerable();

            ints.ForEach(x => sum1 += x);
            ints.ForEach(x => sum2 += square(x));

            Assert.AreEqual(sum1, ints.Sum());
            Assert.AreEqual(sum2, ints.Sum(x=>x*x));

        }
    }
}
