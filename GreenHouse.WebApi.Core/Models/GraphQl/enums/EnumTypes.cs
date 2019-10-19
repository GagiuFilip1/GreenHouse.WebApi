using GraphQL.Types;
using GreenHouse.Core.Models.Enums;
using GreenHouse.Core.Models.GraphQl.requestHelpers;

namespace GreenHouse.Core.Models.GraphQl.enums
{
    public class OrderDirectionEnum : EnumerationGraphType<OrderDirection>
    {
        public OrderDirectionEnum()
        {
            Name = "Order Type";
        }
    }
    
    public class AccountTypeEnum : EnumerationGraphType<AccountType>
    {
        public AccountTypeEnum()
        {
            Name = "Account Type";
        }
    }
    
    public class DeforestStateTypeEnum : EnumerationGraphType<DeforestState>
    {
        public DeforestStateTypeEnum()
        {
            Name = "Deforestation State";
        }
    }
}