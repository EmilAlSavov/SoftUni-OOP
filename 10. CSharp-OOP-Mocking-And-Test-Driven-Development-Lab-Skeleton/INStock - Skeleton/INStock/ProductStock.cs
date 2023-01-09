using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        public ProductStock()
        {
            Products = new List<IProduct>();
        }

        public List<IProduct> Products { get; private set; }

        public IProduct this[int index] 
        { 
            get
            {
                return (IProduct)this[index];
            }
            set => this[index] = value;
        }

        public int Count { get => Products.Count; }

        public void Add(IProduct product) =>
            Products.Add(product);

        public bool Contains(IProduct product)
        {
            if(Products.Contains(product))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IProduct Find(int index) => Products[index];

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            List<IProduct> sortedProducts = new List<IProduct>();

            return sortedProducts = Products.Where(p => p.Price == (decimal)price).ToList();
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            List<IProduct> sortedProducts = new List<IProduct>();

            return sortedProducts = Products.Where(p => p.Quantity == quantity).ToList();
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            List<IProduct> sortedProducts = new List<IProduct>();

            return sortedProducts = Products.Where(p => p.Price >= (decimal)lo && p.Price <= (decimal)hi)
                .OrderByDescending(p => p.Price)
                .ToList();
        }

        public IProduct FindByLabel(string label)
        {
            IProduct product = Products.FirstOrDefault(p => p.Label == label);

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public IProduct FindMostExpensiveProduct()
        {
            IProduct product = Products.OrderBy(p => p.Price).Last();
            return product;
        }

        public IEnumerator<IProduct> GetEnumerator() => Products.GetEnumerator();

        public bool Remove(IProduct product)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
