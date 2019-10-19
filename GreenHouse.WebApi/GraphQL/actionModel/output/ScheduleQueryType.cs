using GraphQL.Types;
using GreenHouse.Core.Models;

namespace GreenHouse.GraphQL.actionModel.output
{
    public class ScheduleQueryType :  ObjectGraphType<Schedule>
    {
        public ScheduleQueryType()
        {
            Field(t => t.Id, false, typeof(StringGraphType));
            Field(t => t.StartDate, false, typeof(StringGraphType));
            Field(t => t.FinishDate, false, typeof(StringGraphType));
            Field(t => t.ReportId, false, typeof(StringGraphType));
        }
    }
}