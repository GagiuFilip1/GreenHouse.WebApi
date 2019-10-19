using System;
using GraphQL.Types;
using GreenHouse.Core.Models;
using GreenHouse.GraphQL.actionModel.input.report;
using GreenHouse.GraphQL.actionModel.output;
using GreenHouse.Repositories.model;

namespace GreenHouse.GraphQL.mutation
{
    public class ReportMutation : ObjectGraphType
    {
        public ReportMutation(IReportRepository repository)
        {
            FieldAsync<ReportQueryType>(
                "addReport",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ReportCreateViewModel>>
                {
                    Name = "report"
                }),
                resolve: async context =>
                {
                    var report = context.GetArgument<Report>("report");
                    return await context.TryAsyncResolve(async _ => await repository.AddAsync(report));
                }
            );

            FieldAsync<AccountQueryType>(
                "removeReport",
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