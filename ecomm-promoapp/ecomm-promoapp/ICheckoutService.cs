using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomm_promoapp
{
    public interface ICheckoutService
    {
        void CheckOut(List<SkuDao> selectedSku);
    }

    public class CheckoutService
    {
        private IPromotions promotions;

        public CheckoutService()
        {
            promotions = new Promotions();
        }

        void CheckOut(List<SkuDao> selectedSku)
        {

        }

        void CalculateTotal(List<SkuDao> selectedSku)
        {
            var promo = promotions.GetActivePromotions();

            var skuA = selectedSku.Where(a => a.SkuName == "A");
            var skuB = selectedSku.Where(a => a.SkuName == "B");
            var skuC = selectedSku.Where(a => a.SkuName == "C");
            var skuD = selectedSku.Where(a => a.SkuName == "D");

            int countsA = skuA.Count();
            int countB = skuB.Count();
            int countC = skuC.Count();
            int countD = skuD.Count();


        }
    }
}
