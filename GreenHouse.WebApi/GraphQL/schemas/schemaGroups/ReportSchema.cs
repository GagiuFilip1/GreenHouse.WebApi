using GreenHouse.GraphQL.mutation;
using GreenHouse.GraphQL.queries;
using GreenHouse.GraphQL.schemas.models;

namespace GreenHouse.GraphQL.schemas.schemaGroups
{
    public class ReportSchema : ISchemaGroup
    {
        public void SetGroup(RootQuery query)
        {
            query.Field<ReportQuery>(
                "report",
                resolve: _ => new { });
        }

        public void SetGroup(RootMutation mutation)
        {
            mutation.Field<ReportMutation>(
                "report",
                resolve: _ => new { });
        }
    }
}