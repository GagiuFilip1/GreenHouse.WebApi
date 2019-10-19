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
using static GreenHouse.Encoder.ShaEncoder;

namespace GreenHouse.Repositories.implementation
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MainContext m_context;

        public AccountRepository(MainContext context) => m_context = context;

        public async Task<Account> AddAsync(Account account)
        {
            account.Id = Guid.NewGuid();
            account.Password = await Encode(account.Password);
            await m_context.Accounts.AddAsync(account);
            await m_context.SaveChangesAsync();
            return account;
        }

        public async Task<Account> RemoveAsync(Guid id)
        {
            var account = await m_context.Accounts.FirstOrDefaultAsync(t => t.Id == id);
            m_context.Accounts.Remove(account);
            await m_context.SaveChangesAsync();
            return account;
        }

        public async Task<Tuple<int, List<Account>>> SearchAsync(AccountFilter filter, PagedRequest pagination,
            OrderedRequest ordering)
        {
            var result = await filter.Filter(m_context.Accounts.AsQueryable().Include(t => t.Friends))
                .WithOrdering(ordering, new OrderedRequest
                {
                    OrderBy = nameof(Account.Id),
                    OrderDirection = Asc
                }).WithPaginationAsync(pagination);
            return result;
        }
    }
}