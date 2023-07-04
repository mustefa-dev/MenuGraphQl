namespace MenuGraph.Types;

public class CategoryQueryType : ObjectType<CategoryQuery>
{
    protected override void Configure(IObjectTypeDescriptor<CategoryQuery> descriptor)
    {
        descriptor.Field(q => q.GetCategories()).Type<ListType<CategoryType>>();
        descriptor.Field(q => q.GetCategory(default)).Type<CategoryType>()
            .Argument("id", arg => arg.Type<NonNullType<IdType>>());
    }
}