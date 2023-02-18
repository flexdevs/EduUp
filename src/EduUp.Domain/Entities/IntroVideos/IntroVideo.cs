using EduUp.Domain.Common;


namespace EduUp.Domain.Entities.IntroVideos
{
    public class IntroVideo : Auditable
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string VideoPath { get; set; } = string.Empty;
        public string PosterImagePath { get; set; } = string.Empty;
    }
}
