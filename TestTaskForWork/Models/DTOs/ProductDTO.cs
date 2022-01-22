using System.Collections.Generic;
using System.Linq;

namespace TestTaskForWork.Models.DTOs
{
    public class ProductDTO
    {
        public ProductDTO(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.Price;
            Category = product.CategoryProducts.Select(c => new ProductCategoryDTO(c)).ToList();
        }

        public int Id { get; set;}
        public string Name { get; set; }

        public int Price { get; set; }
        public List<ProductCategoryDTO> Category { get; set; } = new List<ProductCategoryDTO>();
    }
}