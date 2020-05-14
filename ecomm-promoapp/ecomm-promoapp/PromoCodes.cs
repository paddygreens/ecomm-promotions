using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ecomm_promoapp
{
    public class PromoCodes
    {
        public int Id { get; set; }

        public string PromoName { get; set; }

        public int DiscountedValue { get; set; }

        public bool IsActive { get; set; }
    }
}
