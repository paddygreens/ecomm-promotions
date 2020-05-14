using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomm_promoapp
{
    public interface IPromotions
    {
        List<PromoCodes> GetActivePromotions();

        int ApplyPromotionsAndGetTotal(List<SkuDao> selectedSku);
    }

    public class Promotions : IPromotions
    {
        List<PromoCodes> list;
        public Promotions()
        {
            list = new List<PromoCodes>
            {
                new PromoCodes{Id=1, DiscountedValue = 130, IsActive=true, PromoName= "3As"},
                new PromoCodes{Id=2, DiscountedValue = 45, IsActive=true, PromoName= "2Bs"},
                 new PromoCodes{Id=3, DiscountedValue = 30, IsActive=true, PromoName= "C&D"}
            };
        }

        public List<PromoCodes> GetActivePromotions()
        {
            return list.Where(l => l.IsActive).ToList();
        }

        //TODO : refactor this method
        public int ApplyPromotionsAndGetTotal(List<SkuDao> selectedSku)
        {
            int total = 0;

            var skuA = selectedSku.Where(a => a.SkuName == "A").ToList();
            var skuB = selectedSku.Where(a => a.SkuName == "B");
            var skuC = selectedSku.Where(a => a.SkuName == "C");
            var skuD = selectedSku.Where(a => a.SkuName == "D");

            if (skuA.Count() > 0)
            {
                var s = SplitList<SkuDao>(skuA, 3);
                var promoA = GetActivePromotions().Where(p => p.PromoName == "3As");
                foreach (var item in s)
                {
                    if (item.Count() == 3)
                    {
                        total += promoA.First().DiscountedValue;
                    }
                    else
                    {
                        total += item.Count() * skuA.FirstOrDefault().Price;
                    }
                }
            }

            if (skuB.Count() > 0)
            {
                var b = SplitList<SkuDao>(skuB.ToList(), 2);
                var promoB = GetActivePromotions().Where(p => p.PromoName == "2Bs");
                foreach (var item in b)
                {
                    if (item.Count() == 2)
                    {
                        total += promoB.First().DiscountedValue;
                    }
                    else
                    {
                        total += item.Count() * skuB.FirstOrDefault().Price;
                    }
                }
            }

            if (skuC.Count() > 0 && skuD.Count() > 0)
            {
                var promocd = GetActivePromotions().Where(p => p.PromoName == "C&D");
                if (promocd.Any())
                {
                    if (skuC.Count() == 1 && skuD.Count()==1) 
                    {
                        total += promocd.First().DiscountedValue;
                    }
                    else if (skuC.Count() > 1 && skuD.Count() > 1)
                    {
                        int extrac = skuC.Count() - 1;

                        int extrad = skuD.Count() - 1;
                        if (extrac > 1 && extrad > 1)
                        {
                            total += (extrac * skuC.FirstOrDefault().Price) + (extrad * skuD.FirstOrDefault().Price) + promocd.First().DiscountedValue;
                        }
                    }
                    else if (skuC.Count() > 0)
                    {
                        total += (skuC.Count() * skuC.FirstOrDefault().Price);
                    }
                    else if(skuD.Count() > 0)
                    {
                        total += (skuD.Count() * skuC.FirstOrDefault().Price);
                    }
                }
            }
            else if (skuC.Count() > 0)
            {
                total += (skuC.Count() * skuC.FirstOrDefault().Price);
            }
           else if (skuD.Count() > 0)
            {
                total += (skuD.Count() * skuD.FirstOrDefault().Price);
            }


            return total;
        }

        public static IEnumerable<List<T>> SplitList<T>(List<T> locations, int nSize)
        {
            for (int i = 0; i < locations.Count; i += nSize)
            {
                yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
            }
        } 
    }
}
