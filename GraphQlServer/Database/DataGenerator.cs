using GraphQlServer.Database.Models;
using System;
using Bogus;

namespace GraphQlServer.Database
{
    public class DataGenerator
    {
        public static void Initialize(PostDbContext dbContext)
        {
            var testComments = new Faker<Comment>()
                .RuleFor(_ => _.Id, f => f.UniqueIndex)
                .RuleFor(_ => _.Content, f => f.Lorem.Lines())
                .RuleFor(_ => _.CreatedAt, f => f.Date.Recent())
                .RuleFor(_ => _.CreatedBy, f => f.Person.FullName);


            var testPosts = new Faker<Post>()
                .RuleFor(_ => _.Header, f => f.Lorem.Slug())
                .RuleFor(_ => _.Content, f => f.Lorem.Paragraphs(3))
                .RuleFor(_ => _.CreatedAt, f => f.Date.Recent())
                .RuleFor(_ => _.CreatedBy, f => f.Person.FullName)
                .RuleFor(_=>_.Comments, f => testComments.Generate(5))
                .RuleFor(_=>_.Id, f => f.UniqueIndex)
                .Generate(10);
            dbContext.AddRange(testPosts);
            dbContext.SaveChanges();
        }
    }
}
