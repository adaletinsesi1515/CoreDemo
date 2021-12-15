using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutRepository()); 
        
        public IActionResult Index()
        {
            var values = abm.ListAll();
            return View(values);
        }

        public PartialViewResult SocialMedia()
        {
            return PartialView();
        }
    }
}
