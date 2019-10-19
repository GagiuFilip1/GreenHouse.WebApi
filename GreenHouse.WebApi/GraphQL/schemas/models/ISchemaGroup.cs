using GreenHouse.GraphQL.mutation;
using GreenHouse.GraphQL.queries;

namespace GreenHouse.GraphQL.schemas.models
{
    public interface ISchemaGroup
    {
        void SetGroup(RootQuery query);

        void SetGroup(RootMutation mutation);
    }
}