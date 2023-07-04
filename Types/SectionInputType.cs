using HotChocolate.Types;

namespace MenuGraph.Types
{
    public class SectionInputType : InputObjectType<Section>
    {
        protected override void Configure(IInputObjectTypeDescriptor<Section> descriptor)
        {
            descriptor.Field(s => s.Name).Type<NonNullType<StringType>>();
            descriptor.Field(s => s.CategoryId).Type<NonNullType<StringType>>().Name("categoryId");
        }
    }
}