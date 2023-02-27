using EduUp.DataAccess.Interfaces.Courses;
using EduUp.Service.Common.Utils;
using EduUp.Service.Dtos.Courses;
using EduUp.Service.Interfaces.Courses;
using EduUp.Service.ViewModels.Courses;
using Microsoft.AspNetCore.Mvc;

namespace EduUp.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admins")]
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;
        public readonly int pageSize = 20;
        public CoursesController(ICourseService courseService) 
        {
            _courseService = courseService;
        }  
        [HttpGet]
        public async Task<IActionResult> Index(string search,int page = 1)
        {
            PagedList<CourseViewModel> courses;
            if (!String.IsNullOrEmpty(search))
            {
                ViewBag.search = search;
                courses = await _courseService.GetAllBySearchAsync(search,new PagenationParams(page, pageSize));
            }
            else
            {
                courses = await _courseService.GetAllAsync(new PagenationParams(page,pageSize));    
            }

            return View("Index", courses);
        }

        [HttpGet("create")]
        public  ViewResult Create()
        {
            return View("Create");
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateCourseDto createCourseDto)
        {
            if(ModelState.IsValid) 
            {
               var res = await  _courseService.CreateCourseAsync(createCourseDto);
                if (res)
                {
                    return RedirectToAction("Index", "courses", new {area = "admin"});   
                }
                return Create();
            }
            return Create();
        }
    }
}
