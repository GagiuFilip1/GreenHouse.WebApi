using GreenHouse.GraphQL.mutation;
using GreenHouse.GraphQL.queries;
using GreenHouse.GraphQL.schemas.models;

namespace GreenHouse.GraphQL.schemas.schemaGroups
{
    public class UserFriendSchema : ISchemaGroup
    {
        public void SetGroup(RootQuery query)
        {
            query.Field<UserFriendQuery>(
                "friend",
                resolve: _ => new { });
        }

        public void SetGroup(RootMutation mutation)
        {
            mutation.Field<UserFriendMutation>(
                "friend",
                resolve: _ => new { });
        }
    }
}