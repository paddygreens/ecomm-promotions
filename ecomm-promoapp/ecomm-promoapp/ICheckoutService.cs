using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecomm_promoapp
{
    public interface ICheckoutService
    {
        int CheckOut(List<SkuDao> selectedSku);
    }

    public class CheckoutService
    {
        private IPromotions promotions;

        public CheckoutService()
        {
            promotions = new Promotions();
        }

        public int CheckOut(List<SkuDao> selectedSku)
        {
            return GetTotalPrice(selectedSku);
        }

        private int GetTotalPrice(List<SkuDao> selectedSku)
        {
            int total = promotions.ApplyPromotionsAndGetTotal(selectedSku);
            return total;
        }
    }
}
