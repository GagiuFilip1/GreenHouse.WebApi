using GreenHouse.GraphQL.mutation;
using GreenHouse.GraphQL.mutation.requests;
using GreenHouse.GraphQL.queries;
using GreenHouse.GraphQL.schemas.models;

namespace GreenHouse.GraphQL.schemas.schemaGroups.requests
{
    public class LoginSchema : ISchemaGroup
    {
        public void SetGroup(RootQuery query)
        {
           
        }

        public void SetGroup(RootMutation mutation)
        {
            mutation.Field<LoginRequestMutation>(
                "login",
                resolve: _ => new { });
        }
    }
}