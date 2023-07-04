namespace MenuGraph.Types;

public class ItemInputType : InputObjectType<Item>
{
    protected override void Configure(IInputObjectTypeDescriptor<Item> descriptor)
    {
        descriptor.Field(i => i.Name).Type<NonNullType<StringType>>();
        descriptor.Field(i => i.Price).Type<NonNullType<DecimalType>>();
        descriptor.Field(i => i.SectionId).Type<NonNullType<IdType>>().Name("sectionId");
    }
}