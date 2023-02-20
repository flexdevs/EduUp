using Microsoft.AspNetCore.Http;

namespace EduUp.Service.Interfaces
{
    public interface IFileService
    {
        public Task<string> SaveImageAsync(IFormFile image);
        public Task<string> SaveVideoAsync(IFormFile video);
	}
}
