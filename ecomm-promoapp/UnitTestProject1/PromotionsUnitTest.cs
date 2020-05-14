using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ecomm_promoapp;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class PromotionsUnitTest
    {
        List<SkuDao> selectedSku;

        private IPromotions promotions;

        public PromotionsUnitTest()
        {
            promotions = new Promotions();
        }

        [TestMethod]
        public void ScenarioA()
        {
            //if 1A+1B+1C is selected then total bill will be 100
            selectedSku = new List<SkuDao>
            {
            new SkuDao{Id = 1, SkuName = "A", Price = 50 },
            new SkuDao{Id = 2, SkuName = "B", Price = 30 },
            new SkuDao{Id = 3, SkuName = "C", Price = 20 }
            };

            int total = promotions.ApplyPromotionsAndGetTotal(selectedSku);

            Assert.AreEqual(100, total);
        }

        [TestMethod]
        public void ScenarioB()
        {
            //if 5A+5B+1C is selected then total bill will be 370

            selectedSku = new List<SkuDao>
            {
            new SkuDao{Id = 1, SkuName = "A", Price = 50 },
            new SkuDao{Id = 1, SkuName = "A", Price = 50 },
            new SkuDao{Id = 1, SkuName = "A", Price = 50 },
            new SkuDao{Id = 1, SkuName = "A", Price = 50 },
            new SkuDao{Id = 1, SkuName = "A", Price = 50 },
            new SkuDao{Id = 2, SkuName = "B", Price = 30 },
            new SkuDao{Id = 2, SkuName = "B", Price = 30 },
            new SkuDao{Id = 2, SkuName = "B", Price = 30 },
            new SkuDao{Id = 2, SkuName = "B", Price = 30 },
            new SkuDao{Id = 2, SkuName = "B", Price = 30 },
            new SkuDao{Id = 3, SkuName = "C", Price = 20 }
            };

            int total = promotions.ApplyPromotionsAndGetTotal(selectedSku);

            Assert.AreEqual(370, total);
        }

        [TestMethod]
        public void ScenarioC()
        {
            //if 3A+5B+1C+1D is selected then total bill will be 280
            selectedSku = new List<SkuDao>
            {
            new SkuDao{Id = 1, SkuName = "A", Price = 50 },
            new SkuDao{Id = 1, SkuName = "A", Price = 50 },
            new SkuDao{Id = 1, SkuName = "A", Price = 50 },
            new SkuDao{Id = 2, SkuName = "B", Price = 30 },
            new SkuDao{Id = 2, SkuName = "B", Price = 30 },
            new SkuDao{Id = 2, SkuName = "B", Price = 30 },
            new SkuDao{Id = 2, SkuName = "B", Price = 30 },
            new SkuDao{Id = 2, SkuName = "B", Price = 30 },
            new SkuDao{Id = 3, SkuName = "C", Price = 20 },
            new SkuDao{Id = 3, SkuName = "D", Price = 15 }
            };

            int total = promotions.ApplyPromotionsAndGetTotal(selectedSku);

            Assert.AreEqual(280, total);
        }
    }
}
