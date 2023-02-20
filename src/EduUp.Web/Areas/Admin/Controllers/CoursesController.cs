using EduUp.DataAccess.Interfaces.Courses;
using EduUp.Service.Common.Utils;
using EduUp.Service.Interfaces.Courses;
using Microsoft.AspNetCore.Mvc;

namespace EduUp.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("courses")]
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;
        public readonly int pageSize = 20;
        public CoursesController(ICourseService courseService) 
        {
            _courseService = courseService;
        }  
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            var courses = await _courseService.GetAllAsync(new PagenationParams(page,pageSize));

            return View("Index", courses);
        }
    }
}
