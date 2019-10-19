using System;
using System.Collections.Generic;
using System.Linq;
using GreenHouse.Core.Models;
using GreenHouse.Core.Tools;

namespace GreenHouse.Core.GraphQl.filters
{
    public class AccountFilter : ISearchTermFilter<IQueryable<Account>>
    {
        public List<Guid> Ids { get; } = new List<Guid>();
        public List<string> Names { get; } = new List<string>();

        public AccountFilter()
        {
        }

        public AccountFilter(string searchTerm = null, List<Guid> ids = null, List<string> names = null)
        {
            if (ids != null) Ids = ids;
            if (names != null) Names = names;
            SearchTerm = searchTerm;
        }

        public string SearchTerm { get; set; }

        public IQueryable<Account> Filter(IQueryable<Account> filterQuery)
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

            if (Names.Count > 0)
            {
                filterQuery = filterQuery.Where(t => Names.Any(v => t.Name.Contains(v)));
            }

            return filterQuery;
        }
        
    }
}