

namespace EduUp.Service.Interfaces.Common;

public interface IIdentityService
{
    public long? Id { get; }

    public string FullName { get; }

    public string Email { get; }
    public bool Role { get; }
}
