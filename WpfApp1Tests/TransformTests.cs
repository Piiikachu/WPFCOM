using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Tests
{
    [TestClass()]
    public class TransformTests
    {
        [TestMethod()]
        public void toChannelsTest()
        {
            Assert.AreEqual("018E", Transform.toChannels("010314018E0000018E00000000000000000000000000001275")[0]);
            //Assert.AreEqual(Transform.toChannels("010314018E0000018E00000000000000000000000000001275"),new string[8] { "018E", "0000", "018E", "0000", "0000", "0000", "0000", "0000" });
            //Assert.Fail();
        }

        [TestMethod()]
        public void toDecTest()
        {
            Assert.AreEqual(398, Transform.toDec("018E"));
            //Assert.Fail();
        }

        [TestMethod()]
        public void toPressureTest()
        {
            Assert.AreEqual(0.0, Transform.toPressure(3.98));
            Assert.AreEqual(0.0, Transform.toPressure(4));
            //Assert.AreEqual(10.0, Transform.toPressure(5.6));
            Assert.AreEqual(20.0, Transform.toPressure(7.2));
            Assert.AreEqual(90.0, Transform.toPressure(18.4));
            Assert.AreEqual(100.0, Transform.toPressure(20));
        }

        [TestMethod()]
        public void toPressuresTest()
        {
            Assert.AreEqual(0, Transform.toPressures(new string[] { "018E", "0000", "018E", "0000", "0000", "0000", "0000", "0000" })[0]);
        }
    }
}