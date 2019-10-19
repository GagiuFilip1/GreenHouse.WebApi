using GraphQL.Types;
using GreenHouse.Core.GraphQl.filters;

namespace GreenHouse.GraphQL.actionModel.input.contributor
{
    public class ContributorFilteredRequestType : ObjectGraphType<ContributorFilter>
    {
        public ContributorFilteredRequestType()
        {
            Field(t => t.SearchTerm, true, typeof(StringGraphType));
            Field(t => t.Ids, true, typeof(ListGraphType<StringGraphType>));
        }
    }
}