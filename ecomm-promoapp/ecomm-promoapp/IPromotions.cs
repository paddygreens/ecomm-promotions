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
    }

    public class Promotions : IPromotions
    {
        public Promotions()
        {
            var list = new List<PromoCodes>
            {
                new PromoCodes{Id=1, DiscountedValue = 130, IsActive=true, PromoName= "3As for 130"},
                new PromoCodes{Id=2, DiscountedValue = 45, IsActive=true, PromoName= "2Bs for 45"},
                 new PromoCodes{Id=3, DiscountedValue = 30, IsActive=true, PromoName= "C & D for 30"}
            };
        }

        List<PromoCodes> GetActivePromotions()
        {

        }
    }
}
