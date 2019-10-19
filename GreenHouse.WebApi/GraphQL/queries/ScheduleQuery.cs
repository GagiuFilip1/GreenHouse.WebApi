using System;
using GraphQL.Types;
using GreenHouse.Core.GraphQl.filters;
using GreenHouse.Core.GraphQl.requestHelpers;
using GreenHouse.Core.Models;
using GreenHouse.GraphQL.actionModel.input.schedule;
using GreenHouse.GraphQL.helpers;
using GreenHouse.Repositories.model;

namespace GreenHouse.GraphQL.queries
{
    public class ScheduleQuery : ObjectGraphType
    {
        public ScheduleQuery(IScheduleRepository repository)
        {
            FieldAsync<ListScheduleQueryModelType>(
                "search",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PagedRequestType>> {Name = "pagination"},
                    new QueryArgument<NonNullGraphType<OrderedRequestType>> {Name = "ordering"},
                    new QueryArgument<ScheduleFilteredRequestType> {Name = "filter", DefaultValue = new ScheduleFilter()}
                ),
                resolve: async context =>
                {
                    var filtering = context.GetArgument<ScheduleFilter>("filter");
                    var pagination = context.GetArgument<PagedRequest>("pagination");
                    var ordering = context.GetArgument<OrderedRequest>("ordering");
                    var (count, schedule) = await repository.SearchAsync(filtering, pagination, ordering);
                    return new ListResult<Schedule>
                    {
                        TotalCount = count,
                        Items = schedule
                    };
                }
            );
        }
    }
}