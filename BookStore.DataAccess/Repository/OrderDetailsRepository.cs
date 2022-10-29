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
    public class OrderDetailsRepository : Repository<OrderDetails>, IOrderDetailsRepository
    {
        private readonly ApplicationDbContext dbContext;

        public OrderDetailsRepository(ApplicationDbContext db) : base(db)
        {
            dbContext = db;
        }

        public void update(OrderDetails orderDetails)
        {
            dbContext.OrderDetails.Update(orderDetails);
        }
    }
}
