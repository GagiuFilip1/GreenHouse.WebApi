using System;
using System.Collections.Generic;
using System.Linq;
using GreenHouse.Core.Models;
using GreenHouse.Core.Tools;

namespace GreenHouse.Core.GraphQl.filters
{
    public class UserFriendFilter : ISearchTermFilter<IQueryable<UserFriend>>
    {
        
        public string SearchTerm { get; set; }
        public List<Guid> Ids { get; } = new List<Guid>();

        public UserFriendFilter()
        {
        }

        public UserFriendFilter(string searchTerm = null, List<Guid> ids = null)
        {
            if (ids != null) Ids = ids;
            SearchTerm = searchTerm;
        }

        
        public IQueryable<UserFriend> Filter(IQueryable<UserFriend> filterQuery)
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                if (Guid.TryParse(SearchTerm, out var accId))
                {
                    filterQuery = filterQuery.Where(t => t.Id == accId);
                }
            }

            if (Ids.Count > 0)
            {
                filterQuery = filterQuery.Where(t => Ids.Any(v => v == t.Id));
            }
            
            return filterQuery;
        }
    }
}