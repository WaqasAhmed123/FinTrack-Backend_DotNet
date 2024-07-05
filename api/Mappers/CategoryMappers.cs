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
          public static Category ToCategoryFromCreateDTO(this CreateCategoryRequestDto createCategoryRequestDto)
        {
            return new Category
            {
                CategoryName = createCategoryRequestDto.CategoryName,
            };
        }
    }
}