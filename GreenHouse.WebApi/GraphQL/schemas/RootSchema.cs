using GraphQL;
using GraphQL.Types;
using GreenHouse.GraphQL.mutation;
using GreenHouse.GraphQL.queries;

namespace GreenHouse.GraphQL.schemas
{
    public class RootSchema : Schema
    {
        public RootSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<RootQuery>();
            Mutation = resolver.Resolve<RootMutation>();
        }
    }
}