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
            var obj = dbContext.MenuItem.FirstOrDefault(u => u.Id == menuItem.Id);
            obj.Name = menuItem.Name;
            obj.Description = menuItem.Description;
            obj.Price = menuItem.Price;
            obj.CategoryId = menuItem.CategoryId;
            obj.BookTypeId = menuItem.BookTypeId;

            if (obj.Image != null)
            {
                obj.Image = menuItem.Image;
            }

        }
    }
}
