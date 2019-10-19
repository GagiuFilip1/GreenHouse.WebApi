using System;
using GraphQL.Types;
using GreenHouse.Core.GraphQl.filters;
using GreenHouse.Core.GraphQl.requestHelpers;
using GreenHouse.Core.Models;
using GreenHouse.GraphQL.actionModel.input.contributor;
using GreenHouse.GraphQL.helpers;
using GreenHouse.Repositories.model;

namespace GreenHouse.GraphQL.queries
{
    public class ContributorQuery : ObjectGraphType
    {
        public ContributorQuery(IContributorRepository repository)
        {
            FieldAsync<ListContributorQueryModelType>(
                "search",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PagedRequestType>> {Name = "pagination"},
                    new QueryArgument<NonNullGraphType<OrderedRequestType>> {Name = "ordering"},
                    new QueryArgument<ContributorFilteredRequestType> {Name = "filter", DefaultValue = new ContributorFilter()}
                ),
                resolve: async context =>
                {
                    var filtering = context.GetArgument<ContributorFilter>("filter");
                    var pagination = context.GetArgument<PagedRequest>("pagination");
                    var ordering = context.GetArgument<OrderedRequest>("ordering");
                    var (count, contributors) = await repository.SearchAsync(filtering, pagination, ordering);
                    return new ListResult<Contributor>
                    {
                        TotalCount = count,
                        Items = contributors
                    };
                }
            );
        }
    }
}