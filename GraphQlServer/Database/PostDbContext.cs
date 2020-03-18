using GraphQlServer.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQlServer.Database
{
    public class PostDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("posts");
        }
    }
}
