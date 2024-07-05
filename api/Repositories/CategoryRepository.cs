using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Category;
using api.Interfaces;
using api.Model;
using Microsoft.AspNetCore.Mvc;

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
    }
}