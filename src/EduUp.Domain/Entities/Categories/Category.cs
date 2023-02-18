using EduUp.Domain.Common;


namespace EduUp.Domain.Entities.Categories
{
    public class Category : Auditable
    {
        public string CategoryName { get; set; } = string.Empty;

    }
}
