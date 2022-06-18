using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid Name and Id")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Description of product", 150.00m, 5, "productImage.jpg");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }
        
        [Fact]
        public void CreateProduct_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1,"Product Name", "Description of product", 150.00m, 5, "productImage.jpg");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }


        //Short Name for: Name and Description
        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "PN", "Description of product", 150.00m, 5, "productImage.jpg");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Name. Name is too short, minimum 3 characters!");
        }
        [Fact]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionShortDescription()
        {
            Action action = () => new Product(1, "ProductName", "De", 150.00m, 5, "productImage.jpg");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Description. Description is too short, minimum 3 characters!");
        }


        //Short Name for: Name and Description
        [Fact]
        public void CreateProduct_MissingtNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "", "Description of product", 150.00m, 5, "productImage.jpg");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Name. Name is required!");
        }
        [Fact]
        public void CreateProduct_MissingDescriptionValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "Product Name", "", 150.00m, 5, "productImage.jpg");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Description. Description is required!");
        }



        [Fact]
        public void CreateProduct_WithNullNameValue_DomainExceptionIsInvalidName()
        {
            Action action = () => new Product(1, null, "Description of product", 150.00m, 5, "productImage.jpg");
            action.Should().Throw<Validation.DomainExceptionValidation>();
        }



        [Fact]
        public void CreateProduct_WithNullDescriptionValue_DomainExceptionIsInvalidName()
        {
            Action action = () => new Product(1, "Product Name", null, 150.00m, 5, "productImage.jpg");
            action.Should().Throw<Validation.DomainExceptionValidation>();
        }



        //Image
        [Fact]
        public void CreateProduct_LongImageValue_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Description of product", 150.00m, 5,
                "NameOver250charNameOver250charNameOver250charNameOver250charNameOver250charNameOver250charNameOver250charNameOver250charNameOver250charNameOver250charNameOver250charNameOver250charNameOver250charNameOver250charNameOver250charNameOver250charNameOver250char");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters!");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Description of product", 150.00m, 5, null);
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullRereferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Description of product", 150.00m, 5, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_ExceptionDomainNegativeValue()
        {
            Action action = () => new Product(1, "Product Name", "Description of product", -150.00m, 5, "imageProduct.jpg");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Price Value!");
        }

        [Theory]
        [InlineData (-3)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Product Name", "Description of product", 150.00m, value, "imageProduct.jpg");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Stock Value!");
        }
    }
}
