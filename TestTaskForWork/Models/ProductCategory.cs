using System.Collections.Generic;
using Newtonsoft.Json;
using TestTaskForWork.Models.DTOs;

namespace TestTaskForWork.Models
{
    public class ProductCategory
    {
        public ProductCategory()
        {
            
        }

        public ProductCategory(NewProductCategoryDTO newProductCategory)
        {
            Name = newProductCategory.Name;
        }
        public int Id { get; set; }

        public string Name { get; set; }
        
        public ICollection<Product> Products { get; set; }
        
    }
}