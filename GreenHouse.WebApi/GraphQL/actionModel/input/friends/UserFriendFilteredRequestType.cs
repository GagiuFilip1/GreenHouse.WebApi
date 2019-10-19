using GraphQL.Types;
using GreenHouse.Core.GraphQl.filters;

namespace GreenHouse.GraphQL.actionModel.input.friends
{
    public class UserFriendFilteredRequestType : InputObjectGraphType<UserFriendFilter>
    {
        public UserFriendFilteredRequestType()
        {
            Field(t => t.SearchTerm, true, typeof(StringGraphType));
            Field(t => t.Ids, true, typeof(ListGraphType<StringGraphType>));
        }
    }
}