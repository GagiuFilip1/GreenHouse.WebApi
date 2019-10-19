using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GreenHouse.Core.GraphQl.filters;
using GreenHouse.Core.GraphQl.requestHelpers;
using GreenHouse.Core.Models;

namespace GreenHouse.Repositories.model
{
    public interface IContributorRepository
    {
        Task<Contributor> AddAsync(Contributor contributor);
        Task<Contributor> RemoveAsync(Guid id);
        Task<Tuple<int, List<Contributor>>> SearchAsync(ContributorFilter filter, PagedRequest pagination,
            OrderedRequest ordering);
    }
}