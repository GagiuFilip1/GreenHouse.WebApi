using System;
using GraphQL.Types;
using GreenHouse.Core.GraphQl.filters;
using GreenHouse.Core.GraphQl.requestHelpers;
using GreenHouse.Core.Models;
using GreenHouse.GraphQL.actionModel.input.account;
using GreenHouse.GraphQL.actionModel.input.report;
using GreenHouse.GraphQL.helpers;
using GreenHouse.Repositories.model;

namespace GreenHouse.GraphQL.queries
{
    public class ReportQuery : ObjectGraphType
    {
        public ReportQuery(IReportRepository repository)
        {
            FieldAsync<ListReportQueryModelType>(
                "search",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PagedRequestType>> {Name = "pagination"},
                    new QueryArgument<NonNullGraphType<OrderedRequestType>> {Name = "ordering"},
                    new QueryArgument<ReportFilteredRequestType> {Name = "filter", DefaultValue = new ReportFilter()}
                ),
                resolve: async context =>
                {
                    var filtering = context.GetArgument<ReportFilter>("filter");
                    var pagination = context.GetArgument<PagedRequest>("pagination");
                    var ordering = context.GetArgument<OrderedRequest>("ordering");
                    var (count, reports) = await repository.SearchAsync(filtering, pagination, ordering);
                    return new ListResult<Report>
                    {
                        TotalCount = count,
                        Items = reports
                    };
                }
            );
        }
    }
}