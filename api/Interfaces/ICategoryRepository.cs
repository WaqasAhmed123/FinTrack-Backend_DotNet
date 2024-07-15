using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Category;
using api.Model;
using Microsoft.AspNetCore.Mvc;

namespace api.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<Category>Add(Category category);
        Task<List<Category>> GetAll(string userId);
        Task<Category?> GetCategoryIdByName(string categoryName);
        Task<Category?> GetCategoryNameById(int categoryId);

        
    }
}