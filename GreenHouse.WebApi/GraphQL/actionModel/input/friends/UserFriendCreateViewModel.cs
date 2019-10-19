using GraphQL.Types;
using GreenHouse.Core.Models;

namespace GreenHouse.GraphQL.actionModel.input.friends
{
    public class UserFriendCreateViewModel : InputObjectGraphType<UserFriend>
    {
        public UserFriendCreateViewModel()
        {
            Field(t => t.UserId, false, typeof(NonNullGraphType<StringGraphType>))
                .Description("The id of the user");
            Field(t => t.UserId, false, typeof(NonNullGraphType<StringGraphType>))
                .Description("The id of the friend");
        }
    }
}