using GraphQL.Types;
using GreenHouse.Core.Models;

namespace GreenHouse.GraphQL.actionModel.output
{
    public class ContributorQueryType : ObjectGraphType<Contributor>
    {
        public ContributorQueryType()
        {
            Field(t => t.Id, false, typeof(StringGraphType)).Description("Contributor ID");
            Field(t => t.ReportId, false, typeof(StringGraphType)).Description("Report id that user contributes");
            Field(t => t.UserId, false, typeof(StringGraphType)).Description("The user id  of the contributor");
            Field(t => t.LastUpdated, false, typeof(DateTimeGraphType)).Description("Last time the user updated the report");
        }
    }
}