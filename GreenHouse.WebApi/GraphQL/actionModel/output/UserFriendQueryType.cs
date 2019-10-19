using GraphQL.Types;
using GreenHouse.Core.Models;

namespace GreenHouse.GraphQL.actionModel.output
{
    public class UserFriendQueryType :  ObjectGraphType<UserFriend>
    {
        public UserFriendQueryType()
        {
            Field(t => t.Id, false, typeof(StringGraphType)).Description("Account ID");
            Field(t => t.UserId, false, typeof(StringGraphType)).Description("User Account ID");
            Field(t => t.FriendId, false, typeof(StringGraphType)).Description("Friend Account ID");
        }
    }
}