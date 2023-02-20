using EduUp.Service.Common.Helpers;
using EduUp.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace EduUp.Service.Services
{
    public class FileService : IFileService
    {
        private readonly string images = "images";
        private readonly string videos = "videos";
		private readonly string _rootpath;
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _rootpath = webHostEnvironment.WebRootPath;
        }

        public async Task<string> SaveImageAsync(IFormFile image)
        {
            string imageName = ImageHelper.MakeImageName(image.FileName);

            string imagePath = Path.Combine(_rootpath, images, imageName);
            var stream = new FileStream(imagePath, FileMode.Create);
            try
            {
                await image.CopyToAsync(stream);
                return Path.Combine(images, imageName);
            }
            catch
            {
                return "";
            }
            finally
            {
                stream.Close();
            }
        }

        public async Task<string> SaveVideoAsync(IFormFile video)
        {
            string videoName = VideoHelper.MakeVideoName(video.FileName);

            string videoPath = Path.Combine(_rootpath, videos , videoName);
			var stream = new FileStream(videoPath, FileMode.Create);
            try
            {
                await video.CopyToAsync(stream);
                return Path.Combine(videos, videoName);
            }
			catch
			{
				return "";
			}
			finally
			{
				stream.Close();
			}
		}
    }
}
