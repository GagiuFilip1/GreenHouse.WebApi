using GraphQL.Types;
using GreenHouse.Core.Request.login;

namespace GreenHouse.GraphQL.actionModel.output.requests.login
{
    public class LoginResponseQueryType : ObjectGraphType<LoginResponse>
    {
        public LoginResponseQueryType()
        {
            Field(t => t.Success, false, typeof(StringGraphType)).Description("Success status");
            Field(t => t.Error, false, typeof(StringGraphType)).Description("Errors");
        }
    }
}