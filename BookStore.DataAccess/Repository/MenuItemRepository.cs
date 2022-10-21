using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repository
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly ApplicationDbContext dbContext;
        public MenuItemRepository(ApplicationDbContext db) : base(db)
        {
            dbContext = db;
        }

        public void update(MenuItem menuItem)
        {
            var obj = dbContext.MenuItem.FirstOrDefault(u => u.id == menuItem.id);
            obj.name = menuItem.name;
            obj.description = menuItem.description;
            obj.price = menuItem.price;
            obj.categoryId = menuItem.categoryId;
            obj.bookTypeId = menuItem.bookTypeId;

            if(obj.image != null)
            {
                obj.image = menuItem.image;
            }

        }
    }
}
