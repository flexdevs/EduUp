using EduUp.Domain.Common;
using EduUp.Domain.Entities.Courses;
using EduUp.Domain.Entities.Users;


namespace EduUp.Domain.Entities.Comments
{
    public class Comment : Auditable
    {
        public long UserId { get; set; }
        public virtual User User { get; set; } = default!;
        public long CourseId { get; set; }
        public virtual Course Course { get; set; } = default!;
        public string CommentText { get; set; } = string.Empty;
    }
}
