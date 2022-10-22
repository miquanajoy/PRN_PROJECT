using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;

        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            dbContext = db;
            //Booktype, category
            //dbContext.MenuItem.Include(u => u.BookType).Include(u => u.Category);
            this.dbSet = db.Set<T>();
        }
        public void add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> getAll(string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(includeProperties != null)
            {
                foreach(var includeProperty in includeProperties.Split(
                    new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.ToList();
        }

        public T getFirstOrDefault(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query.FirstOrDefault();
        }

        public void remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void removeRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);

        }
    }
}
