using GraphQL.Types;
using GreenHouse.Core.GraphQl.enums;
using GreenHouse.Core.Models;

namespace GreenHouse.GraphQL.actionModel.output
{
    public class AccountQueryType : ObjectGraphType<Account>
    {
        public AccountQueryType()
        {
            Field(t => t.Id, false, typeof(StringGraphType)).Description("Account ID");
            Field(t => t.Name, false, typeof(StringGraphType)).Description("Account User Name");
            Field(t => t.Email, false, typeof(StringGraphType)).Description("Account Email");
            Field(t => t.Type, false, typeof(AccountTypeEnum)).Description("Account Type");
        }
    }
}