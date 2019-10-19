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
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly MainContext m_context;

        public ScheduleRepository(MainContext mainContext) => m_context = mainContext;

        public async Task<Schedule> AddAsync(Schedule schedule)
        {
            schedule.Id = Guid.NewGuid();
            await m_context.Schedules.AddAsync(schedule);
            await m_context.SaveChangesAsync();
            return schedule;
        }

        public async Task<Schedule> RemoveAsync(Guid id)
        {
            var schedule = await m_context.Schedules.FirstOrDefaultAsync(t => t.Id == id);
            m_context.Schedules.Remove(schedule);
            await m_context.SaveChangesAsync();
            return schedule;
        }

        public async Task<Tuple<int, List<Schedule>>> SearchAsync(ScheduleFilter filter, PagedRequest pagination,
            OrderedRequest ordering)
            => await filter.Filter(m_context.Schedules.AsQueryable())
                .WithOrdering(ordering, new OrderedRequest
                {
                    OrderBy = nameof(Account.Id),
                    OrderDirection = Asc
                })
                .WithPaginationAsync(pagination);
    }
}