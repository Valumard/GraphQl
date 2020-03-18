using GraphQlServer.Database.Models;
using HotChocolate.Types;

namespace GraphQlServer.Database.Schema
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            base.Configure(descriptor);

            descriptor.Field(q => q.GetPostsAsync(default))
                .Type<NonNullType<ListType<NonNullType<PostType>>>>();

            descriptor.Field(q => q.GetPostAsync(default, default))
                .Argument(nameof(Post.Id), a => a.Type<NonNullType<IdType>>());
        }
    }
}
