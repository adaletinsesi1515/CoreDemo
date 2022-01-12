using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass { CategoryName="Teknoloji", CategoryCount=10});
            list.Add(new CategoryClass { CategoryName = "Yazılım", CategoryCount = 14 });
            list.Add(new CategoryClass { CategoryName = "Spor", CategoryCount = 5 });
            list.Add(new CategoryClass { CategoryName = "Sinema", CategoryCount = 2 });
            return Json(new {Jsonlist = list});
        }
    }
}
