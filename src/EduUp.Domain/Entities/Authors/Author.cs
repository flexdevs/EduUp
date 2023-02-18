using EduUp.Domain.Common;

namespace EduUp.Domain.Entities.Authors
{
    public class Author : Auditable
    {
        public string FullName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
    }
}
