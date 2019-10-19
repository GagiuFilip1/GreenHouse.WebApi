using System;
using GraphQL.Types;
using GreenHouse.Core.Models;
using GreenHouse.GraphQL.actionModel.input.account;
using GreenHouse.GraphQL.actionModel.input.friends;
using GreenHouse.GraphQL.actionModel.output;
using GreenHouse.Repositories.model;

namespace GreenHouse.GraphQL.mutation
{
    public class UserFriendMutation : ObjectGraphType
    {
        public UserFriendMutation(IUserFriendRepository repository)
        {
            FieldAsync<UserFriendQueryType>(
                "addFriend",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                    {
                        Name = "friendName"
                    },
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                    {
                        Name = "userId"
                    }
                ),
                resolve: async context =>
                {
                    var name = context.GetArgument<string>("friendName");
                    var user = context.GetArgument<Guid>("userId");
                    return await context.TryAsyncResolve(async _ => await repository.AddAsync(name, user));
                }
            );

            FieldAsync<UserFriendQueryType>(
                "removeFriend",
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