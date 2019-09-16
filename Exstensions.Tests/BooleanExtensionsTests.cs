using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exstensions.Tests
{
    [TestClass]
    public class BooleanExtensionsTests
    {

        [TestMethod]
        public void IfTrue()
        {
            int value1 = 1;
            int value2 = 2;

            const bool @true = true;
            const bool @false = false;

            @true.IfTrue(() => value1 = 1000); // value1 = 1000;
            @false.IfTrue(() => value2 = 2000); // value2 = 2;

            Assert.AreEqual(1000, value1);
            Assert.AreEqual(2, value2);
        }

        [TestMethod]
        public void ToBoolText()
        {
            var @true = true;
            var @false = false;

            Assert.AreEqual("Yes", @true.ToBoolText());
            Assert.AreEqual("No", @false.ToBoolText());
            Assert.AreEqual("1", @true.ToBoolText("1","0"));
            Assert.AreEqual("0", @false.ToBoolText("1", "0"));
        }


        [TestMethod]
        public void ToBoolTextCro()
        {
            var @true = true;
            var @false = false;

            Assert.AreEqual("Da", @true.ToBoolTextCro());
            Assert.AreEqual("Ne", @false.ToBoolTextCro());
            Assert.AreEqual("1", @true.ToBoolTextCro("1", "0"));
            Assert.AreEqual("0", @false.ToBoolTextCro("1", "0"));
        }

    }
}
