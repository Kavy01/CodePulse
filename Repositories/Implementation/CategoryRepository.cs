using Microsoft.EntityFrameworkCore;
using WebApp.Models.Data;
using WebApp.Models.Domain;
using WebApp.Repositories.Interface;

namespace WebApp.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly WebDBContext dbContext;

        public CategoryRepository(WebDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            return category;
        }
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await dbContext.Categories.ToListAsync();
        }
    }
}
