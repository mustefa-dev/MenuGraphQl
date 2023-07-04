using MenuGraph.Types;

public class RootMutationType : ObjectType<RootMutation>
{
    protected override void Configure(IObjectTypeDescriptor<RootMutation> descriptor)
    {
        descriptor.Field(m => m.CreateCategory(default)).Type<CategoryType>()
            .Argument("category", arg => arg.Type<NonNullType<CategoryInputType>>());

        descriptor.Field(m => m.UpdateCategory(default, default)).Type<CategoryType>()
            .Argument("id", arg => arg.Type<NonNullType<IdType>>())
            .Argument("category", arg => arg.Type<NonNullType<CategoryInputType>>());

        descriptor.Field(m => m.DeleteCategory(default)).Type<BooleanType>()
            .Argument("id", arg => arg.Type<NonNullType<IdType>>());

        descriptor.Field(m => m.CreateSection(default)).Type<SectionType>()
            .Argument("section", arg => arg.Type<NonNullType<SectionInputType>>());

        descriptor.Field(m => m.UpdateSection(default, default)).Type<SectionType>()
            .Argument("id", arg => arg.Type<NonNullType<IntType>>())
            .Argument("section", arg => arg.Type<NonNullType<SectionInputType>>());

        descriptor.Field(m => m.DeleteSection(default)).Type<BooleanType>()
            .Argument("id", arg => arg.Type<NonNullType<IntType>>());

        descriptor.Field(m => m.CreateItem(default)).Type<ItemType>()
            .Argument("item", arg => arg.Type<NonNullType<ItemInputType>>());

        descriptor.Field(m => m.UpdateItem(default, default)).Type<ItemType>()
            .Argument("id", arg => arg.Type<NonNullType<IntType>>())
            .Argument("item", arg => arg.Type<NonNullType<ItemInputType>>());

        descriptor.Field(m => m.DeleteItem(default)).Type<BooleanType>()
            .Argument("id", arg => arg.Type<NonNullType<IntType>>());
    }
}