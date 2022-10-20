using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repository.IRepository
{
    public  interface IRepository<T> where T : class
    {
        void add(T entity); 
        void remove(T entity);
        void removeRange(IEnumerable<T> entity);
        IEnumerable<T> GetAll();
        T GetFirstOrDefault(Expression<Func<T, bool>>? filter=null);
    }
}
