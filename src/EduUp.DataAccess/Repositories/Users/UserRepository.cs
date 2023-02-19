using EduUp.DataAccess.DbContexts;
using EduUp.DataAccess.Interfaces.Users;
using EduUp.DataAccess.Repositories.Common;
using EduUp.Domain.Entities.Users;

namespace EduUp.DataAccess.Repositories.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
