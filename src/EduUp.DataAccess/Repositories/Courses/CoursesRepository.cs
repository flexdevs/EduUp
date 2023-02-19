using EduUp.DataAccess.DbContexts;
using EduUp.DataAccess.Interfaces.Courses;
using EduUp.DataAccess.Repositories.Common;
using EduUp.Domain.Entities.Courses;

namespace EduUp.DataAccess.Repositories.Courses
{
    public class CoursesRepository : GenericRepository<Course>, ICourseRepository
    {
        public CoursesRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
