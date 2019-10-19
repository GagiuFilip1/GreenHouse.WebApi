using System;
using GraphQL.Types;
using GreenHouse.Core.Models;
using GreenHouse.GraphQL.actionModel.input.contributor;
using GreenHouse.GraphQL.actionModel.output;
using GreenHouse.Repositories.model;

namespace GreenHouse.GraphQL.mutation
{
    public class ContributorMutation : ObjectGraphType
    {
        public ContributorMutation(IContributorRepository repository)
        {
            FieldAsync<ContributorQueryType>(
                "addContributor",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ContributorCreateViewModel>>
                {
                    Name = "contributor"
                }),
                resolve: async context =>
                {
                    var contributor = context.GetArgument<Contributor>("contributor");
                    return await context.TryAsyncResolve(async _ => await repository.AddAsync(contributor));
                }
            );

            FieldAsync<ContributorQueryType>(
                "removeContributor",
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