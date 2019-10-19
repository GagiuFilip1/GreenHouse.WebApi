using System;
using GraphQL.Types;
using GreenHouse.Core.Models;
using GreenHouse.GraphQL.actionModel.input.account;
using GreenHouse.GraphQL.actionModel.output;
using GreenHouse.Repositories.model;

namespace GreenHouse.GraphQL.mutation
{
    public class AccountMutation : ObjectGraphType
    {
        public AccountMutation(IAccountRepository repository)
        {
            FieldAsync<AccountQueryType>(
                "addAccount",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AccountCreateViewModel>>
                {
                    Name = "account"
                }),
                resolve: async context =>
                {
                    var account = context.GetArgument<Account>("account");
                    return await context.TryAsyncResolve(async _ => await repository.AddAsync(account));
                }
            );

            FieldAsync<AccountQueryType>(
                "removeAccount",
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