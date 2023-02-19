using EduUp.Domain.Common;
using System.Linq.Expressions;

namespace EduUp.DataAccess.Interfaces.Common
{
    public interface IGenericRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public IQueryable<T> GetAll();

        public IQueryable<T> Where(Expression<Func<T, bool>> expression);
    }
}
