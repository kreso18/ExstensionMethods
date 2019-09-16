using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exstensions.Tests
{
    [TestClass]
    public class DateTimeExstensionsTests
    {
        [TestMethod]
        public void ToStringOrDefault()
        {
            DateTime? datetime = new DateTime(2012, 12, 21);
            DateTime? nullDatetime = null;

            Assert.AreEqual("21.12.2012.", datetime.ToStringOrDefault()); //Valid date
            Assert.AreEqual("21-12-12", datetime.ToStringOrDefault("","dd-MM-yy")); //valid date with format 
            Assert.AreEqual("", nullDatetime.ToStringOrDefault()); //null without default value
            Assert.AreEqual("No date!", nullDatetime.ToStringOrDefault("No date!")); //null with default value
        }
    }
}
