using EduUp.Domain.Common;
using EduUp.Domain.Entities.Courses;


namespace EduUp.Domain.Entities.CourseVideos
{
    public class CourseVideo : Auditable
    {
        public long CourseId { get; set; }
        public virtual Course Course { get; set; } = default!;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string VideoPath { get; set; } = string.Empty;
        public string PosterImagePath { get; set; } = string.Empty;
    }
}
