using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exstensions.Tests
{
    [TestClass]
    public class StringExstensionsTests
    {
        [TestMethod]
        public void IsNumeric()
        {
            Assert.IsTrue("0".IsNumeric());
            Assert.IsTrue("123".IsNumeric());

            Assert.IsFalse("-123".IsNumeric());
            Assert.IsFalse("a123".IsNumeric());
        }

        [TestMethod]
        public void TryParseToIntOrDefault()
        {
            Assert.AreEqual(2, "2".TryParseToIntOrDefault());
            Assert.AreEqual(-2, "-2".TryParseToIntOrDefault());

            Assert.AreEqual(0, "0.2".TryParseToIntOrDefault());

            Assert.AreEqual(0, "2a".TryParseToIntOrDefault());
            Assert.AreEqual(-1, "2a".TryParseToIntOrDefault(-1));
        }

        [TestMethod]
        public void ExtractBetween()
        {
            string test1 = "This is <<placeholder>>";
            string test2 = "This is <<placeholder<> inside>>";
            string test3 = "This is empty placeholder <<>>";
            string test4 = "";


            string result1 = test1.ExtractBetween("<<", ">>"); // return "placeholder";
            string result2 = test2.ExtractBetween("<<", ">>"); // return "placeholder<> inside";
            string result3 = test3.ExtractBetween("<<", ">>"); // return "";
            string result4 = test4.ExtractBetween("<<", ">>"); // return "";
            string result5 = test1.ExtractBetween("((", "))"); // return "";

            Assert.AreEqual("placeholder", result1);
            Assert.AreEqual("placeholder<> inside", result2);
            Assert.AreEqual("", result3);
            Assert.AreEqual("", result4);
            Assert.AreEqual("", result5);
        }

        [TestMethod]
        public void ExtractBetweenAtPosition()
        {
            string test1 = "a b {c} {d}";
            string test2 = "This is <<placeholder<> inside>>";
            string test3 = "This is empty placeholder <<>>";
            string test4 = "";


            string result1 = test1.ExtractBetweenAtPosition("{", "}", 1); // return "c";
            string result2 = test1.ExtractBetweenAtPosition("{", "}", 2); // return "d";
            string result3 = test1.ExtractBetweenAtPosition("{", "}", 3); // return "";
       

            Assert.AreEqual("c", result1);
            Assert.AreEqual("d", result2);
            Assert.AreEqual("", result3);
        }
    }
}
