using System.Collections.Generic;

namespace TestTaskForWork.Models.DTOs
{
    public class NewProductDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public List<int> ProductCategoryId { get; set; }
    }
}