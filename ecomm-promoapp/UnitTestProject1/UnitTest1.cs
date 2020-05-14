using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ScenarioA()
        {
            //if 1A+1B+1C is selected then total bill will be 100
        }

        [TestMethod]
        public void ScenarioB()
        {
            //if 5A+5B+1C is selected then total bill will be 370
        }

        [TestMethod]
        public void ScenarioC()
        {
            //if 3A+5B+1C+1D is selected then total bill will be 280
        }
    }
}
