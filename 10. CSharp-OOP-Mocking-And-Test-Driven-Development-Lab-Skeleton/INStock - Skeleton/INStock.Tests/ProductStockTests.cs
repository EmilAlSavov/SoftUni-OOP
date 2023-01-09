namespace INStock.Tests
{
    using NUnit.Framework;

    public class ProductStockTests
    {
        [Test]
        public void AddProduct()
        {
            Product product = new Product("Test Labes", 8.99m, 3);
            ProductStock products = new ProductStock();

            products.Add(product);

            Assert.That(products.Products.Contains(product), Is.True);
        }
    }
}
