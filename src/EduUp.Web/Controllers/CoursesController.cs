using Microsoft.AspNetCore.Mvc;

namespace EduUp.Web.Controllers;

[Route("cources")]
public class CoursesController : Controller
{
	public IActionResult Index()
	{
		ViewBag.Title = "courses";
		return View("Index");
	}
}