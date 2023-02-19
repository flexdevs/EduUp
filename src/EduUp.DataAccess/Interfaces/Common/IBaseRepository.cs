using EduUp.Domain.Common;
using System.Linq.Expressions;


namespace EduUp.DataAccess.Interfaces.Common
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        public void Add(T entity);
        public void Update(long id, T entity);
        public void Delete(long id);
        public Task<T?> FindByIdAsync(long id);
        public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
    }
}


