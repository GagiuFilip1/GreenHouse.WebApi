using GraphQL.Types;
using GreenHouse.Core.Models;

namespace GreenHouse.GraphQL.actionModel.input.contributor
{
    public class ContributorCreateViewModel : ObjectGraphType<Contributor>
    {
        public ContributorCreateViewModel()
        {
            Field(t => t.UserId, false, typeof(NonNullGraphType<StringGraphType>))
                .Description("The id of the contributor");
            Field(t => t.ReportId, false, typeof(NonNullGraphType<StringGraphType>))
                .Description("The report id that the user contribute");
        }
    }
}