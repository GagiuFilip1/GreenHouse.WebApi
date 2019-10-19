using GraphQL.Types;
using GreenHouse.Core.Enums;

namespace GreenHouse.Core.GraphQl.enums
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