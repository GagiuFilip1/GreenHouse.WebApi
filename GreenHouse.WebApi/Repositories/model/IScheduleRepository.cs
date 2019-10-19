using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GreenHouse.Core.GraphQl.filters;
using GreenHouse.Core.GraphQl.requestHelpers;
using GreenHouse.Core.Models;

namespace GreenHouse.Repositories.model
{
    public interface IScheduleRepository
    {
        Task<Schedule> AddAsync(Schedule schedule);
        Task<Schedule> RemoveAsync(Guid id);
        Task<Tuple<int, List<Schedule>>> SearchAsync(ScheduleFilter filter, PagedRequest pagination,
            OrderedRequest ordering);
    }
}