using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Api.Helpers
{
    public class PagingExtensions
    {
        public static IQueryable<TSource> Page<TSource>(IQueryable<TSource> source, int page, int pageSize)
        {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}