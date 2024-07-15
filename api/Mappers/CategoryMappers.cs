using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Category;
using api.Model;

namespace api.Mappers
{
    public static class CategoryMappers
    {

         public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto
            {
                // UserId = statement.UserId,
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
            };
        }
          public static Category ToCategoryFromCreateDTO(this CreateCategoryRequestDto createCategoryRequestDto)
        {
            return new Category
            {
                CategoryName = createCategoryRequestDto.CategoryName,
                UserId = createCategoryRequestDto.UserId
            };
        }
    }
}