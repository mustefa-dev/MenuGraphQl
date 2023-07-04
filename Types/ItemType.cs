
namespace MenuGraph.Types;

public class ItemType : ObjectType<Item>
{
    protected override void Configure(IObjectTypeDescriptor<Item> descriptor)
    {
        descriptor.Field(i => i.Id).Type<NonNullType<UuidType>>();
        descriptor.Field(i => i.Name).Type<NonNullType<StringType>>();
        descriptor.Field(i => i.Price).Type<NonNullType<DecimalType>>();
        descriptor.Field(i => i.SectionId).Type<NonNullType<IntType>>();
        descriptor.Field(i => i.Section).Type<SectionType>();
    }
}
