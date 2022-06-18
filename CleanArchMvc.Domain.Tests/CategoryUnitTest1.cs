using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid Name")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<Validation.DomainExceptionValidation>();
        }
            
        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionIsInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id Value.");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Na");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Name too short, minimum 3 caracters.");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. A name is required.");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionIsInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<Validation.DomainExceptionValidation>();
        }
    
    }
}
