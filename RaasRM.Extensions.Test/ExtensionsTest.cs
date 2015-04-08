using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace RaasRM.Extensions.Test
{
    // Query Types


    public static class RQueryExtensions
    {

        public static IList<TModel> Search<TModel>(this IDbSet<TModel> db, Func<TModel,bool> query) where TModel : class
        {
            return db.Where(query).ToList();
        }

        
    }
}
