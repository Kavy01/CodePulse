using Microsoft.EntityFrameworkCore;
using WebApp.Models.Domain;

namespace WebApp.Models.Data
{
    public class WebDBContext: DbContext
    {
        public WebDBContext(DbContextOptions options) : base(options) { }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
