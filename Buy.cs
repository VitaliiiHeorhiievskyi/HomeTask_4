
using System;
using System.Collections.Generic;

namespace HomeTask2
{
    class Buy
    {
        private List<Product> products;

        public List<Product> Products
        {
            get { return products; }
            set { products = value; }
        }


        public int Count { get; set; }

        private double allPrice;

        public double AllPrice
        {
            get { return allPrice; }
            private set { allPrice = value; }
        }

        private double allWeight;

        public double AllWeight
        {
            get { return allWeight; }
            private set { allWeight = value; }
        }

        public Buy(List<Product> products)
        {
            if (products == null)
                throw new ArgumentNullException("List of product is empty!!");
            Products = new List<Product>(products);

            Count = Products.Count;

            foreach (var product in Products)
            {
                AllPrice += product.Price;
                AllWeight = product.Weight;
            }
        }

        public override string ToString()
        {
            string res = $"\nCount: { Count}\n";
            foreach (var product in Products)
            {
                res += product.ToString()+"\n";
            }
            return res + $"\nAll weight: {AllWeight}g \nAll Price: {AllPrice} UAH";
        }
    }
}
