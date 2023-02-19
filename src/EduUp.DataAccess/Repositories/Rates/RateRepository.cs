using EduUp.DataAccess.DbContexts;
using EduUp.DataAccess.Interfaces.Rates;
using EduUp.DataAccess.Repositories.Common;
using EduUp.Domain.Entities.Rates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.DataAccess.Repositories.Rates
{
    public class RateRepository : GenericRepository<Rate>, IRateRepository
    {
        public RateRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
