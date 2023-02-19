using EduUp.Domain.Entities.Users;

namespace EduUp.Service.Interfaces
{
    public interface IAuthManager
    {
        public string GenerateToken(User user);
    }
}
