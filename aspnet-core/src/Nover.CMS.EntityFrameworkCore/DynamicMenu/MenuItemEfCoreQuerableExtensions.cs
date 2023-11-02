using System.Linq;
using Microsoft.EntityFrameworkCore;
using Nover.CMS.Domain;

namespace Nover.CMS.EntityFrameworkCore
{
    public static class MenuItemEfCoreQueryableExtensions
    {
        public static IQueryable<MenuItem> IncludeDetails(this IQueryable<MenuItem> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .Include(x => x.MenuItems)
                .ThenInclude(x => x.MenuItems);
        }
    }
}