using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exstensions.Tests
{
    [TestClass]
    public class ListExtensionsTests
    {
        [TestMethod]
        public void AddIfNotNull()
        {
            List<string> list = new List<string>();

            string s1 = "aaa";
            string s2 = null;
            string s3 = "ddd";

            list.AddIfNotNull(s1);
            Assert.AreEqual(1, list.Count);

            list.AddIfNotNull(s2); //null
            Assert.AreEqual(1, list.Count); //Length stay the same

            list.AddIfNotNull(s3);
            Assert.AreEqual(2, list.Count);
        }
    }
}
