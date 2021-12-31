using UnitTest.Domain.Entities;
using Xunit;

namespace UnitTest.Test.Domain.Entities
{
    public class BaseProduct
    {
        public Product ProductTest;

        public BaseProduct()
        {
            this.ProductTest = new Product("Tv 50", "Smart Tv Samsung 50 polegadas", 5.500m);
        }
    }

    [Collection("Testings Valid #1")]
    public class ProductTest1 : BaseProduct
    {
        
        [Fact]
        [Trait("Create product", "Valid state")]
        public void CreateProduct_WithValidParameters_ResultValidState()
        {
            var newProduct = new Product("Tv 50", "Smart Tv Samsung 50 polegadas", 5.500m);

            Assert.True(newProduct.Valid);
        }

        [Theory]
        [Trait("Update product", "Valid state")]
        [InlineData("S20 plus", "Smartphone Samsung s20 plus", 8.250)]
        public void UpdateProduct_WithValidParameters_ResultValidState(string name, string description, decimal price)
        {
            this.ProductTest.UpdateProduct(name, description, price);

            Assert.True(this.ProductTest.Valid && this.ProductTest.Name == name && this.ProductTest.Description == description
                && this.ProductTest.Price == price);
        }
    }

    [Collection("Testings Invalid #2")]
    public class ProductTest2 : BaseProduct
    {

        [Theory]
        [Trait("Create product", "Invalid state")]
        [InlineData("", "Smart Tv Samsung 50 polegadas", 5.500)]
        [InlineData("Tv 50", "", 5.500)]
        [InlineData("Tv 50", "Smart Tv Samsung 50 polegadas", 0.0)]
        public void CreateProduct_WithEmptyParameters_ResultInvalidState(string name, string description, decimal price)
        {
            this.ProductTest = new Product(name, description, price);

            Assert.True(this.ProductTest.Invalid);
        }


        [Theory]
        [Trait("Update product", "Invalid state")]
        [InlineData("", "Smart Tv Samsung 50 polegadas", 5.500)]
        [InlineData("Tv 50", "", 5.500)]
        [InlineData("Tv 50", "Smart Tv Samsung 50 polegadas", 0.0)]
        public void UpdateProduct_WithEmptyParameters_ResultInvalidState(string name, string description, decimal price)
        {
            this.ProductTest.UpdateProduct(name, description, price);

            Assert.True(this.ProductTest.Invalid);
        }

        [Theory]
        [Trait("Create product", "Invalid state")]
        [InlineData("Tv 50", "Smart Tv Samsung 50 polegadas", -5.500)]
        [InlineData("Tv 50", "Smart Tv Samsung 50 polegadas", -0.1)]
        public void CreateProduct_WithNegativeValue_ResultInvalidState(string name, string description, decimal price)
        {
            this.ProductTest = new Product(name, description, price);

            Assert.True(this.ProductTest.Invalid);
        }

        [Theory]
        [Trait("Update product", "Invalid state")]
        [InlineData("Tv 50", "Smart Tv Samsung 50 polegadas", -5.500)]
        [InlineData("Tv 50", "Smart Tv Samsung 50 polegadas", -0.1)]
        public void UpdateProduct_WithNegativeValue_ResultInvalidState(string name, string description, decimal price)
        {
            this.ProductTest.UpdateProduct(name, description, price);

            Assert.True(this.ProductTest.Invalid);
        }

        [Theory]
        [Trait("Create product", "Invalid state")]
        [InlineData("Tv", "Smart Tv Samsung 50 polegadas", 5.500)]
        [InlineData("Tv 50", "SS", 0.1)]
        public void CreateProduct_WithLengthInvalid_ResultInvalidState(string name, string description, decimal price)
        {
            this.ProductTest = new Product(name, description, price);

            Assert.True(this.ProductTest.Invalid);
        }

    }
}
