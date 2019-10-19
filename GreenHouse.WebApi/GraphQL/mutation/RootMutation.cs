using System.Collections.Generic;
using GraphQL.Types;
using GreenHouse.GraphQL.schemas.models;

namespace GreenHouse.GraphQL.mutation
{
    public class RootMutation : ObjectGraphType
    {
        public RootMutation(IEnumerable<ISchemaGroup> mutations)
        {
            Name = "Mutations";
            foreach (var mutation in mutations) mutation.SetGroup(this);
        }
    }
}