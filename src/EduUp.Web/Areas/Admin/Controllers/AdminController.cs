using Microsoft.AspNetCore.Mvc;

namespace EduUp.Web.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
