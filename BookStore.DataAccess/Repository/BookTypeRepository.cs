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
    public class BookTypeRepository : Repository<BookType>, IBookTypeRepository
    {
        private readonly ApplicationDbContext dbContext;
        public BookTypeRepository(ApplicationDbContext db) : base(db)
        {
            dbContext = db;
        }

        public void update(BookType bookType)
        {
            var obj = dbContext.BookType.FirstOrDefault(u=>u.Id == bookType.Id);
            obj.Name = bookType.Name;
        }
    }
}
