using GraphQlServer.Database.Models;
using HotChocolate;
using System;
using System.Threading.Tasks;

namespace GraphQlServer.Database.Schema
{
    public class Mutation
    {
        public async Task<Post> SubmitPost([Service] PostDbContext dbContext, SubmitPostInput input)
        {
            var post = new Post
            {
                Header = input.Header,
                Content = input.Content,
                CreatedAt = DateTime.Now,
                CreatedBy = input.Author
            };

            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();

            return post;
        }
    }
}
