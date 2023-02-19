using EduUp.DataAccess.Interfaces.Common;
using EduUp.Domain.Entities.CourseVideos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduUp.DataAccess.Interfaces.CourseVideos
{
    public interface ICourseVideoRepository : GenericRepository<CourseVideo>
    {
    }
}
