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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.DataAccess.Repositories.Common
{ 
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;
        public IAuthorRepository authorRepository { get;}

        public ICategoryRepository categoryRepository { get; }

        public ICommentRepository commentRepository { get; }

        public ICourseRepository courseRepository { get; }

        public ICourseVideoRepository courseVideoRepository { get; }

        public IIntroVideoRepository introVideoRepository  { get;}

     public IOrderRepository orderRepository { get; }

        public IRateRepository rateRepository { get; }

        public IUserRepository userRepository { get; }

        public UnitOfWork(AppDbContext dbContext)
        { 
            this.dbContext = dbContext;
            this.authorRepository = authorRepository;
            this.categoryRepository = categoryRepository;
            this.commentRepository = commentRepository;
            this.courseRepository = courseRepository;
            this.courseVideoRepository = courseVideoRepository;
            this.introVideoRepository = introVideoRepository;
            this.orderRepository = orderRepository;
            this.rateRepository = rateRepository;
            this.userRepository = userRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
