using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repository.IRepository;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            dbContext = db;
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }

        public void Update(Category category)
        {
            var obj = dbContext.Category.FirstOrDefault(u => u.Id == category.Id);
            obj.Name = category.Name;
            obj.DisplayOrder = category.DisplayOrder;
        }
    }
}
