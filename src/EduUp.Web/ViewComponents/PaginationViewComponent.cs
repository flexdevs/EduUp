using EduUp.Service.Common.Utils;
using Microsoft.AspNetCore.Mvc;

namespace EduUp.Web.ViewComponents;

public class PaginationViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(Tuple<string, string, string, string, PagenationMetaData> tuple)
    {
        return View(tuple);
    }
}
