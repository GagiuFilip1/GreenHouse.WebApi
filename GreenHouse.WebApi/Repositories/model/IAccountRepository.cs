using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GreenHouse.Core.GraphQl.filters;
using GreenHouse.Core.GraphQl.requestHelpers;
using GreenHouse.Core.Models;

namespace GreenHouse.Repositories.model
{
    public interface IAccountRepository
    {
        Task<Account> AddAsync(Account account);
        Task<Account> RemoveAsync(Guid id);
        Task<Tuple<int, List<Account>>> SearchAsync(AccountFilter filter, PagedRequest pagination,
            OrderedRequest ordering);
    }
}