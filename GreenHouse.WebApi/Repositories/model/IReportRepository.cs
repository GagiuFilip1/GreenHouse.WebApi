using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GreenHouse.Core.GraphQl.filters;
using GreenHouse.Core.GraphQl.requestHelpers;
using GreenHouse.Core.Models;

namespace GreenHouse.Repositories.model
{
    public interface IReportRepository
    {
        Task<Report> AddAsync(Report report);
        Task<Report> RemoveAsync(Guid id);
        Task<Tuple<int, List<Report>>> SearchAsync(ReportFilter filter, PagedRequest pagination,
            OrderedRequest ordering);
    }
}