using GraphQlServer.Database.Models;
using HotChocolate;
using HotChocolate.Types;
using System.Threading.Tasks;

namespace GraphQlServer.Database.Schema
{
    public class CommentType : ObjectType<Comment>
    {
        protected override void Configure(IObjectTypeDescriptor<Comment> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(_ => _.Id)
                .Type<NonNullType<IdType>>();

            descriptor.Field(_ => _.Content)
                .Type<NonNullType<StringType>>();

            descriptor.Field(_ => _.CreatedAt)
                .Type<NonNullType<DateTimeType>>();

            descriptor.Field(_ => _.CreatedBy)
                .Type<NonNullType<StringType>>();

            descriptor.Field(_ => _.PostId)
                .Ignore();

            descriptor.Field<CommentType>(_ => ResolvePost(default, default))
                .Name("post")
                .Type<PostType>();
        }

        public async Task<Post> ResolvePost([Parent] Comment comment, [Service] PostDbContext dbContext)
        {
            return await dbContext.Posts.FindAsync(comment.PostId);
        }
    }
}
