using EduUp.DataAccess.DbContexts;
using EduUp.DataAccess.Interfaces.Common;
using EduUp.Domain.Common;
using System.Linq.Expressions;

namespace EduUp.DataAccess.Repositories.Common
{
    public class GenericRepository<T> : BaseRepository<T>, IGenericRepository<T> where T : BaseEntity
    {
        public GenericRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public IQueryable<T> GetAll() => _dbSet;

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
            => _dbSet.Where(expression);
    }
}
