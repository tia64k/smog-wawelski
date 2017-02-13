using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmogWawelski;
using SmogWawelski.AppCode;
using SmogWawelski;
using SmogWawelski.Exceptions;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ParserFactory factory = new ParserFactory();

            IApiParser parser = factory.CreateParser(Apis.PowietrzeMalopolskaPl);

            SensorData data = null;
            try
            {
                data = parser.GetSensorData(1);
            }
            catch (SensorNotFoundException ex)
            {
                Assert.Fail();
            }

            Assert.IsNotNull(data);
        }

        [TestMethod]
        public void TestMethod2()
        {
            ParserFactory factory = new ParserFactory();

            IApiParser parser = factory.CreateParser(Apis.PowietrzeMalopolskaPl);

            Dictionary<int, string> data = null;
            try
            {
                data = parser.GetSensorNames();
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }

            Assert.IsNotNull(data);
        }
    }
}
