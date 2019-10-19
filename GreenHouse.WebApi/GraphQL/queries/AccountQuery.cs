using System;
using GraphQL.Types;
using GreenHouse.Core.GraphQl.filters;
using GreenHouse.Core.GraphQl.requestHelpers;
using GreenHouse.Core.Models;
using GreenHouse.GraphQL.actionModel.input.account;
using GreenHouse.GraphQL.helpers;
using GreenHouse.Repositories.model;

namespace GreenHouse.GraphQL.queries
{
    public class AccountQuery : ObjectGraphType
    {
        public AccountQuery(IAccountRepository repository)
        {
            FieldAsync<ListAccountQueryModelType>(
                "search",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PagedRequestType>> {Name = "pagination"},
                    new QueryArgument<NonNullGraphType<OrderedRequestType>> {Name = "ordering"},
                    new QueryArgument<AccountFilteredRequestType> {Name = "filter", DefaultValue = new AccountFilter()}
                ),
                resolve: async context =>
                {
                    var filtering = context.GetArgument<AccountFilter>("filter");
                    var pagination = context.GetArgument<PagedRequest>("pagination");
                    var ordering = context.GetArgument<OrderedRequest>("ordering");
                    var (count, accounts) = await repository.SearchAsync(filtering, pagination, ordering);
                    return new ListResult<Account>
                    {
                        TotalCount = count,
                        Items = accounts
                    };
                }
            );
        }
    }
}