﻿using CleanArchMvc.Domain.Validation;
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

        public Product(string name, string description, decimal price, int stock, string image) //construtor sem Id
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image) //construtor com Id
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id Value.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(int id, string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image) //regra de negócio
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid Name. Name is required!");
            DomainExceptionValidation.When(name.Length < 3, "Invalid Name. Name is too short, minimum 3 characters!");//
            Name = name;

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid Description. Description is required!");
            DomainExceptionValidation.When(description.Length < 5, "Invalid Description. Description is too short, minimum 3 characters!");//
            Description = description;
            
            DomainExceptionValidation.When(price < 0, "Invalid Price value!");
            Price = price;
            
            DomainExceptionValidation.When(stock < 0, "Invalid Stock value!");
            Stock = stock;

            DomainExceptionValidation.When(image?.Length > 250, "Invalid image name, too long, maximum 250 characters!");//
            Image = image;
        }
    }
}
