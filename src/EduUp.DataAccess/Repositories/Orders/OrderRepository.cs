using EduUp.DataAccess.DbContexts;
using EduUp.DataAccess.Interfaces.Orders;
using EduUp.DataAccess.Repositories.Common;
using EduUp.Domain.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.DataAccess.Repositories.Orders
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
