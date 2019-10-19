using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreenHouse.Context;
using GreenHouse.Context.extensions;
using GreenHouse.Core.GraphQl.filters;
using GreenHouse.Core.GraphQl.requestHelpers;
using GreenHouse.Core.Models;
using GreenHouse.Repositories.model;
using Microsoft.EntityFrameworkCore;
using static GreenHouse.Core.Enums.OrderDirection;

namespace GreenHouse.Repositories.implementation
{
    public class ReportRepository : IReportRepository
    {
        private readonly MainContext m_context;

        public ReportRepository(MainContext mainContext) => m_context = mainContext;

        public async Task<Report> AddAsync(Report report)
        {
            report.Id = Guid.NewGuid();
            await m_context.Reports.AddAsync(report);
            await m_context.SaveChangesAsync();
            return report;
        }

        public async Task<Report> RemoveAsync(Guid id)
        {
            var report = await m_context.Reports.FirstOrDefaultAsync(t => t.Id == id);
            m_context.Reports.Remove(report);
            await m_context.SaveChangesAsync();
            return report;
        }

        public async Task<Tuple<int, List<Report>>> SearchAsync(ReportFilter filter, PagedRequest pagination, OrderedRequest ordering)
            => await filter.Filter(m_context.Reports.AsQueryable())
                .WithOrdering(ordering, new OrderedRequest
                {
                    OrderBy = nameof(Account.Id),
                    OrderDirection = Asc
                })
                .WithPaginationAsync(pagination);
    }
}