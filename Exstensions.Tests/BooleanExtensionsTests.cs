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

       
    }
}
