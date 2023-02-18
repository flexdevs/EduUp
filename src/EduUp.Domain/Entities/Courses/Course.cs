using EduUp.Domain.Common;
using EduUp.Domain.Entities.Authors;
using EduUp.Domain.Entities.Categories;
using EduUp.Domain.Entities.IntroVideos;


namespace EduUp.Domain.Entities.Courses
{
    public class Course : Auditable
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public double Price { get; set; }
        public long AuthorId { get; set; }
        public virtual Author Author { get; set; } = default!;
        public long CategoryId { get; set; }
        public virtual Category Category { get; set; } = default!;
        public long IntroVideoId { get; set; }
        public virtual IntroVideo IntroVideo { get; set; } = default!;
    }
}
