using GraphQL.Types;
using GreenHouse.Core.Models;

namespace GreenHouse.GraphQL.actionModel.input.schedule
{
    public class ScheduleCreateViewModel : InputObjectGraphType<Schedule>
    {
        public ScheduleCreateViewModel()
        {
            Field(t => t.ReportId, false, typeof(NonNullGraphType<StringGraphType>))
                .Description("The id of the report this schedule is applied");
            Field(t => t.StartDate, false, typeof(NonNullGraphType<StringGraphType>))
                .Description("The date the schedule starts");
            Field(t => t.FinishDate, false, typeof(NonNullGraphType<StringGraphType>))
                .Description("The date the schedule is over");
        }
    }
}