using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GreenHouse.Core.GraphQl.filters;
using GreenHouse.Core.GraphQl.requestHelpers;
using GreenHouse.Core.Models;

namespace GreenHouse.Repositories.model
{
    public interface IUserFriendRepository
    {
        Task<UserFriend> AddAsync(string friendName, Guid userId);
        Task<UserFriend> RemoveAsync(Guid id);
        Task<Tuple<int, List<UserFriend>>> SearchAsync(UserFriendFilter filter, PagedRequest pagination,
            OrderedRequest ordering);
    }
}