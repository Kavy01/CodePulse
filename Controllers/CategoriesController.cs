using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Data;
using WebApp.Models.Domain;
using WebApp.Repositories.Interface;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repository;

        public CategoriesController(ICategoryRepository repository)
        {
            this._repository = repository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            var response = await _repository.CreateAsync(category);
            return Ok(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _repository.GetAllAsync();
            var response = new List<Category>();
            foreach (var category in categories)
            {
                response.Add(new Category
                { 
                    Id = category.Id,
                    Name = category.Name, 
                    UrlHandle = category.UrlHandle 
                });

            }
            return Ok(response);

        }
        [HttpGet]
        [Route("id:Guid")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var response = await _repository.GetCategoryById(id);
            if(response is null)
            {
                return NotFound("No such user found");
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("id:Guid")]
        public async Task<IActionResult> EditCategory(Guid id, Category request)
        {
            var category = new Category
            {
                Id = id,
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };
            category = await _repository.UpdateAsync(category);
            if(category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpDelete]
        [Route("id:Guid")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var category = await _repository.DeleteAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
    }
}
