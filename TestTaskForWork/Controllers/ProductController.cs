using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTaskForWork.Data;
using TestTaskForWork.Models;
using TestTaskForWork.Models.DTOs;


namespace TestTaskForWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ProductController(MyDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public Task<List<ProductDTO>> GetProducts()
        {
            return _context.Products
                .Include(c => c.CategoryProducts)
                .Select(p => new ProductDTO(p))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var data = await _context.Products.Include(b => b.CategoryProducts)
                .Where(p => p.Id == id).Select(p => new ProductDTO(p)).FirstOrDefaultAsync();
            if (data == null)
                return NotFound();
            else
                return data;
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDTO>> PutProduct(int id, UpdateProductDTO updateProduct)
        {
            var product = await _context.Products
                .Include(p => p.CategoryProducts)
                .AsTracking()
                .SingleOrDefaultAsync(c => c.Id == updateProduct.Id);
                

            if (product == null)
            {
                return NotFound();
            }

            product.Name = updateProduct.Name;
            product.Price = updateProduct.Price;
            //dopisat price

            if (updateProduct.CategoriesId != null)
            {
                var categoriesToRemove = product.CategoryProducts.ToList();

                foreach (var categoryToRemove in categoriesToRemove)
                {
                    product.CategoryProducts.Remove(categoryToRemove);
                }

                var categoriesToAdd = await _context.CategoryProducts
                    .Where(c => updateProduct.CategoriesId.Contains(c.Id))
                    .AsTracking()
                    .ToListAsync();

                foreach (var categoryToAdd in categoriesToAdd)
                {
                    product.CategoryProducts.Add(categoryToAdd);
                }

            }
            await _context.SaveChangesAsync();
            return NoContent();
        }
        
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> PostProduct(NewProductDTO newProduct)
        {
            var product = new Product(newProduct);
            foreach (var categoryId in newProduct.ProductCategoryId)
            {
                var category = await _context.CategoryProducts
                    .AsTracking()
                    .SingleOrDefaultAsync(c => c.Id == categoryId);
                if (category != null)
                {
                    product.CategoryProducts.Add(category);
                }
                
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), 
                new { id = product.Id }, new ProductDTO(product));
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}