using EduUp.DataAccess.DbContexts;
using EduUp.DataAccess.Interfaces.Authors;
using EduUp.DataAccess.Repositories.Common;
using EduUp.Domain.Entities.Authors;


namespace EduUp.DataAccess.Repositories.Authors
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
