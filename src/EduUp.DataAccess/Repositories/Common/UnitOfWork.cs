using EduUp.DataAccess.DbContexts;
using EduUp.DataAccess.Interfaces.Authors;
using EduUp.DataAccess.Interfaces.Categories;
using EduUp.DataAccess.Interfaces.Comments;
using EduUp.DataAccess.Interfaces.Common;
using EduUp.DataAccess.Interfaces.Courses;
using EduUp.DataAccess.Interfaces.CourseVideos;
using EduUp.DataAccess.Interfaces.IntroVideos;
using EduUp.DataAccess.Interfaces.Orders;
using EduUp.DataAccess.Interfaces.Rates;
using EduUp.DataAccess.Interfaces.Users;
using EduUp.DataAccess.Repositories.Authors;
using EduUp.DataAccess.Repositories.Categories;
using EduUp.DataAccess.Repositories.Comments;
using EduUp.DataAccess.Repositories.Courses;
using EduUp.DataAccess.Repositories.CourseVideos;
using EduUp.DataAccess.Repositories.IntroVideos;
using EduUp.DataAccess.Repositories.Orders;
using EduUp.DataAccess.Repositories.Rates;
using EduUp.DataAccess.Repositories.Users;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EduUp.DataAccess.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public IAuthorRepository Authors { get; }
        public ICategoryRepository Categories { get; }
        public ICommentRepository Comments { get; }
        public ICourseRepository Courses { get; }
        public ICourseVideoRepository CourseVideos { get; }
        public IIntroVideoRepository IntroVideos { get; }
        public IOrderRepository Orders { get; }
        public IRateRepository Rates { get; }
        public IUserRepository Users { get; }

        public UnitOfWork(AppDbContext AppDbContext)
        {
            dbContext = AppDbContext;
            Authors = new AuthorRepository(AppDbContext);
            Categories = new CategoryRepository(AppDbContext);
            Comments = new CommentRepository(AppDbContext);
            Courses = new CoursesRepository(AppDbContext);
            CourseVideos = new CourseVideoRepository(AppDbContext);
            IntroVideos = new IntroVideoRepository(AppDbContext);
            Orders = new OrderRepository(AppDbContext);
            Rates = new RateRepository(AppDbContext);
            Users = new UserRepository(AppDbContext);
        }

        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return dbContext.Entry(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
