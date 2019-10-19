using System;
using GraphQL.Types;
using GreenHouse.Core.Models;
using GreenHouse.GraphQL.actionModel.input.schedule;
using GreenHouse.GraphQL.actionModel.output;
using GreenHouse.Repositories.model;

namespace GreenHouse.GraphQL.mutation
{
    public class ScheduleMutation : ObjectGraphType
    {
        public ScheduleMutation(IScheduleRepository repository)
        {
            FieldAsync<ScheduleQueryType>(
                "addSchedule",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ScheduleCreateViewModel>>
                {
                    Name = "schedule"
                }),
                resolve: async context =>
                {
                    var schedule = context.GetArgument<Schedule>("schedule");
                    return await context.TryAsyncResolve(async _ => await repository.AddAsync(schedule));
                }
            );

            FieldAsync<ScheduleQueryType>(
                "removeSchedule",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>>
                {
                    Name = "id"
                }),
                resolve: async context =>
                {
                    var id = context.GetArgument<string>("id");
                    return await context.TryAsyncResolve(
                        async _ => await repository.RemoveAsync(Guid.Parse(id))
                    );
                }
            );
        }
    }
}