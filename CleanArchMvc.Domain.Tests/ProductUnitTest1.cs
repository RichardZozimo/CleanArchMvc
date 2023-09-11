using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Null Name Value")]
        public void CreateProduct_CreateWithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99M, 99, "Product Image");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Invalid Id")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99M, 99, "Product Image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Product With Short Name Value")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "PN", "Product Description", 9.99M, 99, "Product Image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Too short, minimum 3 characters!");
        }

        [Fact(DisplayName = "Create Product With Empty Name Value")]
        public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "", "Product Description", 9.99M, 99, "Product Image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Product name is required!");
        }

        [Fact(DisplayName = "Create Product With Null Name Value")]
        public void CreateProduct_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Product(1, null, "Product Description", 9.99M, 99, "Product Image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Short Description Value")]
        public void CreateProduct_WithShortDescription_DomainExceptionTooShortDescription()
        {
            Action action = () => new Product(1, "ProductName", "Product", 9.99M, 99, "Product Image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Too short, minimum 8 characters!");
        }

        [Fact(DisplayName = "Create Product With Empty Description Value")]
        public void CreateProduct_DescriptionValueEmpty_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "ProductName", "", 9.99M, 99, "Product Image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Product description is required!");
        }

        [Fact(DisplayName = "Create Product With Null Description Value")]
        public void CreateProduct_DescriptionNull_DomainExceptionInvalidDescription()
        {
            Action action = () => new Product(1, "ProductName", null, 9.99M, 99, "Product Image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Product description is required!");
        }

        [Fact(DisplayName = "Create Product With Negative Price Value")]
        public void CreateProduct_WithNegativePrice_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "ProductName", "Product Description", -1, 99, "Product Image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value!");
        }

        [Theory(DisplayName = "Create Product With Negative Stock Value")]
        [InlineData(-5)]
        public void CreateProduct_WithNegativeStock_DomainExceptionInvalidStock(int stock)
        {
            Action action = () => new Product(1, "ProductName", "Product Description", 9.99M, stock, "Product Image");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value!");
        }

        [Fact(DisplayName = "Create Product With Too Long Image Value")]
        public void CreateProduct_WithTooLongImageValue_DomainExceptionImageTooLong()
        {
            Action action = () => new Product(1, "ProductName", "Product Description", 9.99M, 99, "Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long Product Image Is Too Long");
            action.Should()
                .Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters!");
        }

        [Fact(DisplayName = "Create Product With Empty Image Value")]
        public void CreateProduct_WithEmptyImageValue_NoDomainException()
        {
            Action action = () => new Product(1, "ProductName", "Product Description", 9.99M, 99, "");
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Null Image Value")]
        public void CreateProduct_WithImageNull_NoDomainException()
        {
            Action action = () => new Product(1, "ProductName", "Product Description", 9.99M, 99, null);
            action.Should()
                .NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product With Null Image Value")]
        public void CreateProduct_WithImageNull_NoNullReferenceException()
        {
            Action action = () => new Product(1, "ProductName", "Product Description", 9.99M, 99, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }
    }
}
