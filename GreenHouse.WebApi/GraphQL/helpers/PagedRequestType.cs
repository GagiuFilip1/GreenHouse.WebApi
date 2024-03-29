using GraphQL.Types;
using GreenHouse.Core.GraphQl.requestHelpers;

namespace GreenHouse.GraphQL.helpers
{
    public class PagedRequestType : InputObjectGraphType<PagedRequest>
    {
        public PagedRequestType()
        {
            Field(x => x.Take, true);
            Field(x => x.Offset, true);
        }
    }
}