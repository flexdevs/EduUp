using EduUp.DataAccess.DbContexts;
using EduUp.DataAccess.Interfaces.Orders;
using EduUp.DataAccess.Repositories.Common;
using EduUp.Domain.Entities.Orders;

namespace EduUp.DataAccess.Repositories.Orders
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
