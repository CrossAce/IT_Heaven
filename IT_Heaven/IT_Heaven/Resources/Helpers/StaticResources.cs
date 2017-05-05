using IT_Heaven.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IT_Heaven.Resources.Helpers
{
    public class StaticResources
    {
        public static int CurrentCategory { get; set; }
        public static MessageIds Message { get; set; }

        public static string CalculateDiscount(int discount , decimal startingPrice)
        {
            decimal newPrice = 0;
            if (discount != 0)
            {
                newPrice = startingPrice * (discount * 0.01M);
                var total = startingPrice - newPrice;
                return $"{total.ToString("c")} ({discount}% Discount)";
            }
            return $"{startingPrice.ToString("c")}";

        }

    }
}