using HotChocolate.Types;
using MenuGraph.Models;

public class CategoryInputType : InputObjectType<Category>
{
    protected override void Configure(IInputObjectTypeDescriptor<Category> descriptor)
    {
        descriptor.Field(c => c.Name).Type<NonNullType<StringType>>();
    }
}