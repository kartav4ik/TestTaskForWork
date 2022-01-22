using System;
using System.Collections.Generic;
using TestTaskForWork.Models.DTOs;

namespace TestTaskForWork.Models
{
    public class Product
    {
        public Product()
        {
            
        }

        public Product(NewProductDTO newProduct)
        {
            Name = newProduct.Name;
            Price = newProduct.Price;
        }
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int Price { get; set; }

        public ICollection<ProductCategory> CategoryProducts { get; set; } = new List<ProductCategory>();
    }

}