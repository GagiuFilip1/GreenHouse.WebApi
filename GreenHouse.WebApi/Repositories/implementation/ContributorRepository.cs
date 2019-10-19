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
    public class ContributorRepository : IContributorRepository
    {
        private readonly MainContext m_context;

        public ContributorRepository(MainContext mainContext) => m_context = mainContext;

        public async Task<Contributor> AddAsync(Contributor contributor)
        {
            contributor.Id = Guid.NewGuid();
            await m_context.Contributors.AddAsync(contributor);
            await m_context.SaveChangesAsync();
            return contributor;
        }

        public async Task<Contributor> RemoveAsync(Guid id)
        {
            var contributor = await m_context.Contributors.FirstOrDefaultAsync(t => t.Id == id);
            m_context.Contributors.Remove(contributor);
            await m_context.SaveChangesAsync();
            return contributor;
        }

        public async Task<Tuple<int, List<Contributor>>> SearchAsync(ContributorFilter filter, PagedRequest pagination, OrderedRequest ordering)
            => await filter.Filter(m_context.Contributors.AsQueryable())
                .WithOrdering(ordering, new OrderedRequest
                {
                    OrderBy = nameof(Account.Id),
                    OrderDirection = Asc
                })
                .WithPaginationAsync(pagination);    }
}