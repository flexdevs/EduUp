using EduUp.DataAccess.Interfaces.Authors;
using EduUp.DataAccess.Interfaces.Categories;
using EduUp.DataAccess.Interfaces.Comments;
using EduUp.DataAccess.Interfaces.Courses;
using EduUp.DataAccess.Interfaces.CourseVideos;
using EduUp.DataAccess.Interfaces.IntroVideos;
using EduUp.DataAccess.Interfaces.Orders;
using EduUp.DataAccess.Interfaces.Rates;
using EduUp.DataAccess.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.DataAccess.Interfaces.Common
{
    public interface IUnitOfWork
    {
        public IAuthorRepository authorRepository { get; }
        public ICategoryRepository categoryRepository { get; }
        public ICommentRepository commentRepository { get; }
        public ICourseRepository courseRepository { get; }
        public ICourseVideoRepository courseVideoRepository { get; }
        public IIntroVideoRepository introVideoRepository { get; }
        public IOrderRepository orderRepository { get; }
        public IRateRepository rateRepository { get; }
        public IUserRepository userRepository { get; }
        public Task<int> SaveChangesAsync();
    }
}

