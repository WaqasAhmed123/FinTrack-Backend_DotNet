using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Category;
using api.Interfaces;
using api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{


    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Category> Add(Category category)
        {
            // var category = new Category
            // {
            //     CategoryName = createCategoryRequestDto.CategoryName
            // };

            // Add the entity to the context
            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync(); // Don't forget to save changes

            // Return a success result (could also return the created category or an ID)
            return category;

        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category?> GetCategoryIdByName(string categoryName)
        {
            return await _context.Category
                                 .FirstOrDefaultAsync(c => c.CategoryName == categoryName);
        }
        public async Task<Category?> GetCategoryNameById(int categoryId)
        {
            return await _context.Category
                                 .FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }
    }
}