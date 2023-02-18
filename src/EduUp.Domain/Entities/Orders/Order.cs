using EduUp.Domain.Common;
using EduUp.Domain.Entities.Courses;
using EduUp.Domain.Entities.Users;


namespace EduUp.Domain.Entities.Orders
{
    public class Order : Auditable
    {
        public long UserId { get; set; }
        public virtual User User { get; set; } = default!;
        public long CourseId { get; set; }
        public virtual Course Course { get; set; } = default!;
        public double Price { get; set; }   
       
    }

}
