using EduUp.DataAccess.DbContexts;
using EduUp.DataAccess.Interfaces.Comments;
using EduUp.DataAccess.Repositories.Common;
using EduUp.Domain.Entities.Comments;

namespace EduUp.DataAccess.Repositories.Comments
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
