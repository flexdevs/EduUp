using EduUp.DataAccess.Interfaces.Authors;
using EduUp.DataAccess.Interfaces.Categories;
using EduUp.DataAccess.Interfaces.Comments;
using EduUp.DataAccess.Interfaces.Courses;
using EduUp.DataAccess.Interfaces.CourseVideos;
using EduUp.DataAccess.Interfaces.IntroVideos;
using EduUp.DataAccess.Interfaces.Orders;
using EduUp.DataAccess.Interfaces.Rates;
using EduUp.DataAccess.Interfaces.Users;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EduUp.DataAccess.Interfaces.Common
{
    public interface IUnitOfWork
    {
        public IAuthorRepository Authors { get; }
        public ICategoryRepository Categories { get; }
        public ICommentRepository Comments { get; }
        public ICourseRepository Courses { get; }
        public ICourseVideoRepository CourseVideos { get; }
        public IIntroVideoRepository IntroVideos { get; }
        public IOrderRepository Orders { get; }
        public IRateRepository Rates { get; }
        public IUserRepository Users { get; }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        public Task<int> SaveChangesAsync();
    }
}

