using GraphQL.Types;
using GreenHouse.Core.Request.login;
using GreenHouse.GraphQL.actionModel.input.requests.login;
using GreenHouse.GraphQL.actionModel.output.requests.login;
using GreenHouse.Services.models;

namespace GreenHouse.GraphQL.mutation.requests
{
    public class LoginRequestMutation : ObjectGraphType
    {
        public LoginRequestMutation(ILoginService loginService)
        {
            FieldAsync<LoginResponseQueryType>(
                "login",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<LoginRequestCreateViewModel>>
                {
                    Name = "request"
                }),
                resolve: async context =>
                {
                    var request = context.GetArgument<LoginRequest>("request");
                    return await context.TryAsyncResolve(async _ => await loginService.SendLoginRequestAsync(request));
                }
            );
        }
    }
}