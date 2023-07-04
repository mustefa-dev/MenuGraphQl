namespace MenuGraph.GraphQL;

public class RootMutationType : ObjectType<CategoryMutation>
{
    protected override void Configure(IObjectTypeDescriptor<CategoryMutation> descriptor)
    {
        descriptor.Field(m => m.CreateCategory(default)).Type<CategoryType>()
            .Argument("category", arg => arg.Type<NonNullType<CategoryInputType>>());

        descriptor.Field(m => m.UpdateCategory(default, default)).Type<CategoryType>()
            .Argument("id", arg => arg.Type<NonNullType<IdType>>())
            .Argument("category", arg => arg.Type<NonNullType<CategoryInputType>>());

        descriptor.Field(m => m.DeleteCategory(default)).Type<BooleanType>()
            .Argument("id", arg => arg.Type<NonNullType<IdType>>());
    }
}
