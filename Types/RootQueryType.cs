namespace MenuGraph.Types;

public class RootQueryType : ObjectType<RootQuery>
{
    protected override void Configure(IObjectTypeDescriptor<RootQuery> descriptor)
    {
        descriptor.Field(q => q.GetCategories()).Type<ListType<CategoryType>>();
        descriptor.Field(q => q.GetCategory(default)).Type<CategoryType>()
            .Argument("id", arg => arg.Type<NonNullType<IdType>>());

        descriptor.Field(q => q.GetSectionsByCategoryId(default)).Type<ListType<SectionType>>()
            .Argument("categoryId", arg => arg.Type<NonNullType<StringType>>())
            .Name("sectionsByCategoryId");

        descriptor.Field(q => q.GetSection(default)).Type<SectionType>()
            .Argument("id", arg => arg.Type<NonNullType<IdType>>());

        descriptor.Field(q => q.GetItemsBySectionId(default)).Type<ListType<ItemType>>()
            .Argument("sectionId", arg => arg.Type<NonNullType<IntType>>())
            .Name("itemsBySectionId");

        descriptor.Field(q => q.GetItem(default)).Type<ItemType>()
            .Argument("id", arg => arg.Type<NonNullType<IdType>>());

        descriptor.Field(q => q.GetAllSections()).Type<ListType<SectionType>>();
        descriptor.Field(q => q.GetAllItems()).Type<ListType<ItemType>>();
    }
}