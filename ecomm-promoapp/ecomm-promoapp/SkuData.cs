using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomm_promoapp
{
    public static class SkuData
    {
        public static List<SkuDao> CreateData()
        {
            var lst = new List<SkuDao>(){
            new SkuDao{Id = 1, SkuName = "A", Price = 50 },
            new SkuDao{Id = 2, SkuName = "B", Price = 30 },
            new SkuDao{Id = 3, SkuName = "C", Price = 20 },
            new SkuDao{Id = 4, SkuName = "D", Price = 15 }
            };

            return lst;
        }
    }
}
