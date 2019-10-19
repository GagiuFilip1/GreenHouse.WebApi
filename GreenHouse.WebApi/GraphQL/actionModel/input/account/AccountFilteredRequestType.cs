using GraphQL.Types;
using GreenHouse.Core.GraphQl.filters;

namespace GreenHouse.GraphQL.actionModel.input.account
{
    public class AccountFilteredRequestType : InputObjectGraphType<AccountFilter>
    {
        public AccountFilteredRequestType()
        {
            Field(t => t.SearchTerm, true, typeof(StringGraphType));
            Field(t => t.Ids, true, typeof(ListGraphType<StringGraphType>));
            Field(t => t.Names, true, typeof(ListGraphType<StringGraphType>));
        }
    }
}