using EduUp.Domain.Common;

namespace EduUp.Domain.Entities.Users
{
    public class User : Auditable
    {
        public string FullName { get; set; }   = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } =string.Empty;
        public string Salt { get; set; } = string.Empty;
        public bool EmailVerify { get; set; }   
        public string ImagePath = string.Empty; 
        public bool UserRole { get; set; }  
    }
}
