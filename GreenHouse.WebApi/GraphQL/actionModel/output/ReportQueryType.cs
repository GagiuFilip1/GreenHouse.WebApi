using GraphQL.Types;
using GreenHouse.Core.GraphQl.enums;
using GreenHouse.Core.Models;

namespace GreenHouse.GraphQL.actionModel.output
{
    public class ReportQueryType : ObjectGraphType<Report>
    {
        public ReportQueryType()
        {
            Field(t => t.Id, false, typeof(StringGraphType));
            Field(t => t.ReportedAt, false, typeof(DateTimeGraphType));
            Field(t => t.FinishedAt, false, typeof(DateTimeGraphType));
            Field(t => t.State, false, typeof(ForestStateTypeEnum));
            Field(t => t.UserId, false, typeof(StringGraphType));
            Field(t => t.Description, false, typeof(StringGraphType));
            Field(t => t.IsScheduled, false, typeof(BooleanGraphType));
        }
    }
}