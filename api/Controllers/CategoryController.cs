using api.Dtos.Category;
using api.Mappers;
using api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [Route("api/category")]
    [ApiController]
    public class CategoryController: ControllerBase
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CreateCategoryRequestDto createCategoryRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryModel = createCategoryRequestDto.ToCategoryFromCreateDTO();
            var category = await _categoryRepository.Add(categoryModel);

            if (category == null)
                return StatusCode(500, "An error occurred while adding the category.");

            return Ok(category);
        }

    }
}