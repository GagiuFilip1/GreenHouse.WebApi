using GreenHouse.GraphQL.mutation;
using GreenHouse.GraphQL.queries;
using GreenHouse.GraphQL.schemas.models;

namespace GreenHouse.GraphQL.schemas.schemaGroups
{
    public class ScheduleSchema : ISchemaGroup
    {
        public void SetGroup(RootQuery query)
        {
            query.Field<ScheduleQuery>(
                "schedule",
                resolve: _ => new { });
        }

        public void SetGroup(RootMutation mutation)
        {
            mutation.Field<ScheduleMutation>(
                "schedule",
                resolve: _ => new { });
        }
    }
}