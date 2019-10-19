using GraphQL.Types;
using GreenHouse.Core.GraphQl.enums;
using GreenHouse.Core.Models;

namespace GreenHouse.GraphQL.actionModel.input.report
{
    public class ReportCreateViewModel: InputObjectGraphType<Report>
    {
        public ReportCreateViewModel()
        {
            Field(t => t.UserId, false, typeof(NonNullGraphType<StringGraphType>))
                .Description("The id of the user");
            Field(t => t.Description, true, typeof(StringGraphType))
                .Description("The id of the user");
            Field(t => t.State, true, typeof(ForestStateTypeEnum))
                .Description("The id of the user");
            Field(t => t.IsScheduled, true, typeof(BooleanGraphType))
                .Description("The id of the user");
            Field(t => t.FinishedAt, true, typeof(DateTimeGraphType))
                .Description("The id of the user");
        }
    }
}