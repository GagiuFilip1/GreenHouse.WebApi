using GreenHouse.Core.Models;
using GreenHouse.GraphQL.mutation;
using GreenHouse.GraphQL.queries;
using GreenHouse.GraphQL.schemas.models;

namespace GreenHouse.GraphQL.schemas.schemaGroups
{
    public class ContributorSchema : ISchemaGroup
    {
        public void SetGroup(RootQuery query)
        {
            query.Field<ContributorQuery>(
                "contributor",
                resolve: _ => new { });
        }

        public void SetGroup(RootMutation mutation)
        {
            mutation.Field<ContributorMutation>(
                "contributor",
                resolve: _ => new { });
        }
    }
}