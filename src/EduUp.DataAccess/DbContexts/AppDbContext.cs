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
using System.Net;

namespace EduUp.DataAccess.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContext)
            : base(dbContext)
        {

        }

        public virtual DbSet<Author> Authors { get; set;}
        public virtual DbSet<Category> Categories { get; set;}
        public virtual DbSet<Comment> Comments { get; set;}
        public virtual DbSet<Course> Courses { get; set;}
        public virtual DbSet<CourseVideo> CourseVideos { get; set;}
        public virtual DbSet<IntroVideo> IntroVideos { get; set;}
        public virtual DbSet<Order> Orders { get; set;}
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
