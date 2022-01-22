using System.Collections.Generic;

namespace TestTaskForWork.Models.DTOs
{
    public class UpdateProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }
        public List<int> CategoriesId { get; set; }
    }
}