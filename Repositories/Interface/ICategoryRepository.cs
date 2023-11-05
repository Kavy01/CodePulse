using Microsoft.AspNetCore.Mvc;
using WebApp.Models.Domain;

namespace WebApp.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetCategoryById(Guid id);

        Task<Category?> UpdateAsync(Category category);

        Task<Category?> DeleteAsync(Guid id);
    }
}
