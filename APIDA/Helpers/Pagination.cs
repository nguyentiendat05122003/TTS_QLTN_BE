using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAPI.Helpers
{
    public class Pagination
    {
        public static IList<T> GetPage<T>(IQueryable<T> query, int page, int pageSize) where T: class
        {
            var skip = (page - 1) * pageSize;
            return query.Skip(skip).Take(pageSize).ToList();
        }
    }
}
