using EduUp.Domain.Entities.Authors;
using EduUp.Domain.Entities.Categories;
using EduUp.Domain.Entities.Comments;
using EduUp.Domain.Entities.Courses;
using EduUp.Domain.Entities.CourseVideos;
using EduUp.Domain.Entities.IntroVideos;
using EduUp.Domain.Entities.Orders;
using EduUp.Domain.Entities.Rates;
using EduUp.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace EduUp.DataAccess.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContext)
            : base(dbContext)
        {

        }

        public virtual DbSet<Author> Authors { get; set; } = default!;
        public virtual DbSet<Category> Categories { get; set; } = default!;
        public virtual DbSet<Comment> Comments { get; set; } = default!;
        public virtual DbSet<Course> Courses { get; set; } = default!;
        public virtual DbSet<CourseVideo> CourseVideos { get; set; } = default!;
        public virtual DbSet<IntroVideo> IntroVideos { get; set; } = default!;
        public virtual DbSet<Order> Orders { get; set; } = default!;
        public virtual DbSet<Rate> Rates { get; set; } = default!;
        public virtual DbSet<User> Users { get; set; } = default!;

    }
}
