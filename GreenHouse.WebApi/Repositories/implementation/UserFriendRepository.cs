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
    public class UserFriendRepository : IUserFriendRepository
    {
        private readonly MainContext m_context;

        public UserFriendRepository(MainContext context) => m_context = context;

        public async Task<UserFriend> AddAsync(string friendName, Guid userId)
        {
            var friendUser = await m_context.Accounts.Where(t => t.Name == friendName).FirstOrDefaultAsync();
            var friend = new UserFriend
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                FriendId = friendUser.Id
            };
            
            var friendReverse = new UserFriend
            {
                Id = Guid.NewGuid(),
                UserId = friendUser.Id,
                FriendId = userId
            };
            
            await m_context.Friends.AddAsync(friend);
            await m_context.Friends.AddAsync(friendReverse);
            
            await m_context.SaveChangesAsync();
            return friend;
        }

        public async Task<UserFriend> RemoveAsync(Guid id)
        {
            var account = await m_context.Friends.FirstOrDefaultAsync(t => t.Id == id);
            m_context.Friends.Remove(account);
            await m_context.SaveChangesAsync();
            return account;
        }

        public async Task<Tuple<int, List<UserFriend>>> SearchAsync(UserFriendFilter filter, PagedRequest pagination,
            OrderedRequest ordering)
            => await filter.Filter(m_context.Friends.AsQueryable())
                .WithOrdering(ordering, new OrderedRequest
                {
                    OrderBy = nameof(Account.Id),
                    OrderDirection = Asc
                })
                .WithPaginationAsync(pagination);
    }
}