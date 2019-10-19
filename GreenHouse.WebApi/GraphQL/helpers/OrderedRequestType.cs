using GraphQL.Types;
using GreenHouse.Core.GraphQl.enums;
using GreenHouse.Core.GraphQl.requestHelpers;

namespace GreenHouse.GraphQL.helpers
{
    public class OrderedRequestType : InputObjectGraphType<OrderedRequest>
    {
        public OrderedRequestType()
        {
            Field(x => x.OrderBy, true).Description("Name of the Property to sort by");
            Field<OrderDirectionEnum>("orderDirection", resolve: _ => _.Source.OrderDirection);
        }
    }
}