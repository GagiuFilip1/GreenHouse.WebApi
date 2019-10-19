using System.Collections.Generic;
using GraphQL.Types;

namespace GreenHouse.GraphQL.helpers
{
    public class ListResponseType<T> : ObjectGraphType<object> where T : IGraphType
    {
        protected ListResponseType()
        {
            Field<IntGraphType>().Name("totalCount")
                .Description("A count of the total number of objects in this connection, ignoring pagination.");
            Field<ListGraphType<T>>().Name("items")
                .Description("A list of all of the objects returned in the connection.");
        }
    }

    public class ListResult<T>
    {
        public long TotalCount { get; set; }
        public IList<T> Items { get; set; }
    }
}