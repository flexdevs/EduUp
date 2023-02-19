using EduUp.DataAccess.DbContexts;
using EduUp.DataAccess.Interfaces.Comments;
using EduUp.DataAccess.Repositories.Common;
using EduUp.Domain.Entities.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.DataAccess.Repositories.Comments
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
