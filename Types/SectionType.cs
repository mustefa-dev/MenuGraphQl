namespace MenuGraph.Types;

public class SectionType : ObjectType<Section>
{
    protected override void Configure(IObjectTypeDescriptor<Section> descriptor)
    {
        descriptor.Field(s => s.Id).Type<NonNullType<UuidType>>();
        descriptor.Field(s => s.Name).Type<NonNullType<StringType>>();
        descriptor.Field(s => s.CategoryId).Name("categoryId").Type<NonNullType<UuidType>>();
        descriptor.Field(s => s.Category).Type<CategoryType>();
        descriptor.Field(s => s.Items).Type<ListType<ItemType>>();
    }
}