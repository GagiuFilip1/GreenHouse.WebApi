using GraphQL.Types;
using GreenHouse.Core.GraphQl.filters;

namespace GreenHouse.GraphQL.actionModel.input.schedule
{
    public class ScheduleFilteredRequestType: InputObjectGraphType<ScheduleFilter>
    {
        public ScheduleFilteredRequestType()
        {
            Field(t => t.SearchTerm, true, typeof(StringGraphType));
            Field(t => t.Ids, true, typeof(ListGraphType<StringGraphType>));
        }
    }
}