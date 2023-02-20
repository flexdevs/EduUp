using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduUp.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admins")]
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

      
    }
}
