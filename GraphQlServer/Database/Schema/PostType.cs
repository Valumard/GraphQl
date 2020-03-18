using GraphQlServer.Database.Models;
using HotChocolate;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlServer.Database.Schema
{
    public class PostType : ObjectType<Post>
    {
        protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(_ => _.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(_ => _.Header)
                .Type<NonNullType<StringType>>();

            descriptor.Field(_ => _.Content)
                .Type<NonNullType<StringType>>();

            descriptor.Field(_ => _.CreatedAt)
                .Type<NonNullType<DateTimeType>>();

            descriptor.Field(_=>_.CreatedBy)
                .Type<NonNullType<StringType>>();

            descriptor.Field<PostType>(_ => ResolveComments(default, default))
                .Name("comments")
                .Type<ListType<CommentType>>();
        }

        public async Task<IReadOnlyList<Comment>> ResolveComments([Parent] Post post, [Service] PostDbContext dbContext)
        {
            return await dbContext.Comments
                .Where(c => c.PostId == post.Id)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }
    }
}
