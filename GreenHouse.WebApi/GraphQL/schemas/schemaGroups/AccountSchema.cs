using GreenHouse.GraphQL.mutation;
using GreenHouse.GraphQL.queries;
using GreenHouse.GraphQL.schemas.models;

namespace GreenHouse.GraphQL.schemas.schemaGroups
{
    public class AccountSchema : ISchemaGroup
    {
        public void SetGroup(RootQuery query)
        { 
            query.Field<AccountQuery>(
                "account",
                resolve: _ => new { });
        }

        public void SetGroup(RootMutation mutation)
        {
            mutation.Field<AccountMutation>(
                "account",
                resolve: _ => new { });
        }
    }
}