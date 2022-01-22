using Microsoft.EntityFrameworkCore;
using TestTaskForWork.Models;

namespace TestTaskForWork.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        } 
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> CategoryProducts { get; set; }
        
    }
}