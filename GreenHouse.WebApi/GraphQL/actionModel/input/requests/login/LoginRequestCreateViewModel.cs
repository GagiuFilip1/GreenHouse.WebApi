using GraphQL.Types;
using GreenHouse.Core.Request.login;

namespace GreenHouse.GraphQL.actionModel.input.requests.login
{
    public class LoginRequestCreateViewModel : InputObjectGraphType<LoginRequest>
    {
        public LoginRequestCreateViewModel()
        {
            Field(t => t.Email, false, typeof(NonNullGraphType<StringGraphType>))
                .Description("The name of the user");
            Field(t => t.Password, false, typeof(NonNullGraphType<StringGraphType>))
                .Description("The name of the user");
        }
    }
}