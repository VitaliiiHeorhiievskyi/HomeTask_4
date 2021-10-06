using System;
using System.Collections.Generic;

namespace HomeTask2
{
    sealed class Check
    {
        public static string DisplayProduct(in Product product)
        {
            return product+"";
        }

        public static string DisplayBuy(in Buy buy)
        {
            return "\nShop receipt\n" + buy.ToString();
        }

        public static string DisplayProducts(in List<Product> products)
        {
            if (products == null)
            {
                return "\nArray is empty!!";
            }
            string res = "\nCheck\n";
            foreach (var product in products)
            {
                res+=DisplayProduct(product);
            }
            return res;
        }
    }
}
