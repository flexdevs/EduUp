using EduUp.Domain.Entities.Categories;
using EduUp.Service.Common.Utils;
using EduUp.Service.Dtos.Categories;
using EduUp.Service.Interfaces.Categories;
using EduUp.Service.ViewModels.Courses;
using Microsoft.AspNetCore.Mvc;

namespace EduUp.Web.Areas.Admin.Controllers;

[Area("admin")]
[Route("categories")]
public class CategoriesController : Controller
{
    private readonly ICategoryService _categoryService;
    private readonly int pageSize = 10;

    public CategoriesController(ICategoryService categoryService) 
    {
        _categoryService = categoryService;
    }
    [HttpGet]
    public async Task<IActionResult> Index(string search, int page =1)
    {
        PagedList<Category> categories;
        if (!String.IsNullOrEmpty(search))
        {
            ViewBag.search = search;
            categories = await _categoryService.GetAllBySearchAsync(search, new PagenationParams(page, pageSize));
        }
        else
        {
            categories = await _categoryService.GetAllAsync(new PagenationParams(page, pageSize));
        }

            return View("Index", categories);
    }

    [HttpGet("create")]
    public ViewResult Create()
    {
        return View("Create");
    }
  
    
}
