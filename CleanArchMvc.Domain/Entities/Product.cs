using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public int CategoryId { get; private set; }
        public Category Category { get; private set; }


        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }
        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Product name is required!");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name. Too short, minimum 3 characters!");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description. Product description is required!");

            DomainExceptionValidation.When(description.Length < 8,
                "Invalid description. Too short, minimum 8 characters!");

            DomainExceptionValidation.When(price < 0,
                "Invalid price value!");

            DomainExceptionValidation.When(stock < 0,
                "Invalid stock value!");

            DomainExceptionValidation.When(image?.Length > 250,
                "Invalid image name, too long, maximum 250 characters!");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
}
