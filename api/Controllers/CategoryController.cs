using api.Dtos.Category;
using api.Interfaces;
using api.Mappers;
using api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{

    [Route("api/category")]
    [ApiController]
    public class CategoryController: ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCategory([FromBody] CreateCategoryRequestDto createCategoryRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryModel = createCategoryRequestDto.ToCategoryFromCreateDTO();
            var category = await _categoryRepository.Add(categoryModel);

            if (category == null)
                return StatusCode(500, "An error occurred while adding the category.");

            return Ok(category.ToCategoryDto());
        }

         [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _categoryRepository.GetAll();
            var categoryDto = users.Select(c => c.ToCategoryDto());

            return Ok(categoryDto);
        }

    }
}