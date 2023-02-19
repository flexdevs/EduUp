using EduUp.DataAccess.DbContexts;
using EduUp.DataAccess.Interfaces.Rates;
using EduUp.DataAccess.Repositories.Common;
using EduUp.Domain.Entities.Rates;

namespace EduUp.DataAccess.Repositories.Rates
{
    public class RateRepository : GenericRepository<Rate>, IRateRepository
    {
        public RateRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
