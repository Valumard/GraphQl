using GraphQlServer.Database.Models;
using HotChocolate;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlServer.Database.Schema
{
    public class Query
    {
        public async Task<IReadOnlyList<Post>> GetPostsAsync([Service] PostDbContext dbContext)
        {
            var result = await dbContext.Posts
                .OrderByDescending(_ => _.CreatedAt)
                .ToListAsync();
            return result;
        }

        public async Task<Post> GetPostAsync([Service] PostDbContext dbContext, int id)
            => await dbContext.Posts.FirstOrDefaultAsync(_ => _.Id == id);
    }
}
