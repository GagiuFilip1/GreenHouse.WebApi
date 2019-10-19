using GraphQL.Types;
using GreenHouse.Core.GraphQl.filters;

namespace GreenHouse.GraphQL.actionModel.input.report
{
    public class ReportFilteredRequestType: InputObjectGraphType<ReportFilter>
    {
        public ReportFilteredRequestType()
        {
            Field(t => t.SearchTerm, true, typeof(StringGraphType));
            Field(t => t.Ids, true, typeof(ListGraphType<StringGraphType>));
        }
    }
}