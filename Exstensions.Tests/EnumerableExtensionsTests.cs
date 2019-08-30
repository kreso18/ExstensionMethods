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
            Assert.AreEqual(sum2, ints.Sum(x => x * x));

        }

        [TestMethod]
        public void WithMinimum()
        {
            var squareOfThreeOrIntMax = new Func<int, int>(x => x == 3 ? x*x : int.MaxValue);

            var objects = new List<Tuple<int, string>>()
            {
                new Tuple<int, string>(1, "one"),
                new Tuple<int, string>(2, "two"),
                new Tuple<int, string>(3, "three"),
                new Tuple<int, string>(4, "four"),
            };

            var min1 = objects.WithMinimum(x => x.Item1); //returns (1, "one")
            var min2 = objects.WithMinimum(x => x.Item2.Length); //returns (1, "one")
            var min3 = objects.WithMinimum(x => squareOfThreeOrIntMax(x.Item1)); //returns (3, "three")

            Assert.AreEqual(min1.Item1, 1);
            Assert.AreEqual(min2.Item1, 1);
            Assert.AreEqual(min3.Item1, 3);

            Assert.AreEqual(min1.Item1, objects.OrderBy(x => x.Item1).First().Item1);

        }

        [TestMethod]
        public void WithMaximum()
        {
            var squareOfThreeOrZero = new Func<int, int>(x => x == 3 ? x * x : 0);

            var objects = new List<Tuple<int, string>>()
            {
                new Tuple<int, string>(1, "one"),
                new Tuple<int, string>(2, "two"),
                new Tuple<int, string>(3, "three"),
                new Tuple<int, string>(4, "four"),
                new Tuple<int, string>(7, "seven"),
            };

            var max1 = objects.WithMaximum(x => x.Item1); //returns (7, "seven")
            var max2 = objects.WithMaximum(x => x.Item2.Length); //returns (3, "three")
            var max3 = objects.WithMaximum(x => squareOfThreeOrZero(x.Item1)); //returns (3, "three")

            Assert.AreEqual(max1.Item1, 7);
            Assert.AreEqual(max2.Item1, 3);
            Assert.AreEqual(max3.Item1, 3);

            Assert.AreEqual(max1.Item1, objects.OrderByDescending(x=>x.Item1).First().Item1);
        }
    }
}
