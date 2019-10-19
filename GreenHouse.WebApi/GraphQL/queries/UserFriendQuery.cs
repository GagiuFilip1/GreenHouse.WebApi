using System;
using GraphQL.Types;
using GreenHouse.Core.GraphQl.filters;
using GreenHouse.Core.GraphQl.requestHelpers;
using GreenHouse.Core.Models;
using GreenHouse.GraphQL.actionModel.input.account;
using GreenHouse.GraphQL.actionModel.input.friends;
using GreenHouse.GraphQL.helpers;
using GreenHouse.Repositories.model;

namespace GreenHouse.GraphQL.queries
{
    public class UserFriendQuery : ObjectGraphType
    {
        public UserFriendQuery(IUserFriendRepository repository)
        {
            FieldAsync<ListUserFriendQueryModelType>(
                "search",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PagedRequestType>> {Name = "pagination"},
                    new QueryArgument<NonNullGraphType<OrderedRequestType>> {Name = "ordering"},
                    new QueryArgument<UserFriendFilteredRequestType> {Name = "filter", DefaultValue = new UserFriendFilter()}
                ),
                resolve: async context =>
                {
                    var filtering = context.GetArgument<UserFriendFilter>("filter");
                    var pagination = context.GetArgument<PagedRequest>("pagination");
                    var ordering = context.GetArgument<OrderedRequest>("ordering");
                    var (count, friends) = await repository.SearchAsync(filtering, pagination, ordering);
                    return new ListResult<UserFriend>
                    {
                        TotalCount = count,
                        Items = friends
                    };
                }
            );
        }
    }
}