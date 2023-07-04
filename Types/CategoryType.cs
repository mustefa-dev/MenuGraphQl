using HotChocolate.Types;
using MenuGraph.Models;

public class CategoryType : ObjectType<Category>
{
    protected override void Configure(IObjectTypeDescriptor<Category> descriptor)
    {
        descriptor.Field(c => c.Id).Type<NonNullType<IdType>>();
        descriptor.Field(c => c.Name).Type<NonNullType<StringType>>();
    }
}