using System;

namespace TestTaskForWork.Models.DTOs
{
    public class ProductCategoryDTO
    {
        public ProductCategoryDTO(ProductCategory category)
        {
            Id = category.Id;
            Name = category.Name;
        }
        
        public int Id { get; set; }
        
        public String Name { get; set; }
    }
}