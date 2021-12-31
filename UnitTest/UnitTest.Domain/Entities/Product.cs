using System;
using UnitTest.Domain.Validations.EntitiesValidation;

namespace UnitTest.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public Product(string name, string description, decimal price)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;


            Validate(this, new ProductValidation());

            if (this.Valid)
            {
                this.CreateDate = DateTime.Now;
            }
        }

        public void UpdateProduct(string name, string description, decimal price)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;

            Validate(this, new ProductValidation());

            if (this.Valid)
            {
                this.UpdateDate = DateTime.Now;
            }
        }
    }
}
