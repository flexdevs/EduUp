using EduUp.DataAccess.DbContexts;
using EduUp.DataAccess.Interfaces.CourseVideos;
using EduUp.DataAccess.Repositories.Common;
using EduUp.Domain.Entities.CourseVideos;

namespace EduUp.DataAccess.Repositories.CourseVideos
{
    public class CourseVideoRepository : GenericRepository<CourseVideo>, ICourseVideoRepository
    {
        public CourseVideoRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
