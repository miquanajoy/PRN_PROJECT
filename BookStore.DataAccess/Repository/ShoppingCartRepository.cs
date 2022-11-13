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
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext dbContext;

        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            dbContext = db;
        }

        public int decrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count -= count;
            dbContext.SaveChanges();
            return shoppingCart.Count;
        }

        public int incrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count += count;
            dbContext.SaveChanges();
            return shoppingCart.Count;
        }
    }
}
