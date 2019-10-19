using GraphQL.Types;
using GreenHouse.Core.GraphQl.enums;
using GreenHouse.Core.Models;

namespace GreenHouse.GraphQL.actionModel.input.account
{
    public class AccountCreateViewModel : InputObjectGraphType<Account>
    {
        public AccountCreateViewModel()
        {
            Field(t => t.Name, false, typeof(NonNullGraphType<StringGraphType>))
                .Description("The name of the user");
            Field(t => t.Email, false, typeof(NonNullGraphType<StringGraphType>))
                .Description("The email of the user");
            Field(t => t.Password, false, typeof(NonNullGraphType<StringGraphType>))
                .Description("The password of the user");
            Field(t => t.Type, false, typeof(NonNullGraphType<AccountTypeEnum>))
                .Description("The type of the user");
        }
    }
}