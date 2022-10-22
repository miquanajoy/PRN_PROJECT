using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;
        
        public UnitOfWork(ApplicationDbContext db)
        {
            dbContext = db;
            Category = new CategoryRepository(dbContext);
            BookType = new BookTypeRepository(dbContext);
            MenuItem = new MenuItemRepository(dbContext);
        }

        public ICategoryRepository Category { get; private set; }

        public IBookTypeRepository BookType { get; private set; }
        public IMenuItemRepository MenuItem { get; private set; }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public void save()
        {
            dbContext.SaveChanges();
        }
    }
}
