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
        public async Task<Category?> GetCategoryById(Guid id)
        {
            return await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> UpdateAsync(Category category)
        {
            var existingCategory = await dbContext.Categories.FirstOrDefaultAsync(x =>  x.Id == category.Id);

            if (existingCategory != null)
            {
                dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
                dbContext.SaveChangesAsync();
                return category;
            }
            return null;
        }
        public async Task<Category?> DeleteAsync(Guid id)
        {
            var existingCategory = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if(existingCategory is null) 
            {
                return null;
            }
            dbContext.Categories.Remove(existingCategory);
            await dbContext.SaveChangesAsync();
            return existingCategory;
        }
    }
}
