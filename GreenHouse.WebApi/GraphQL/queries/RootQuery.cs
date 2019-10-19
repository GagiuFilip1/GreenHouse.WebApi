using System.Collections.Generic;
using GraphQL.Types;
using GreenHouse.GraphQL.schemas.models;

namespace GreenHouse.GraphQL.queries
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(IEnumerable<ISchemaGroup> queries)
        {
            Name = "Query";
            foreach (var query in queries) query.SetGroup(this);
        }
    }
}