using GreenHouse.Core.Models.Enums;

namespace GreenHouse.Core.Models.GraphQl.requestHelpers
{
    public class OrderedRequest
    {
        private string m_orderBy;

        public string OrderBy
        {
            get => m_orderBy;
            set => m_orderBy = value?.ToLower();
        }

        public OrderDirection OrderDirection { get; set; }
    }
}