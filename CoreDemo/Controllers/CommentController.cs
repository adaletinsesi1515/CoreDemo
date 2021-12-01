using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PartialAddComment()
        {
            return PartialView();
        }

        public IActionResult CommentListByBlog()
        {
            return PartialView();
        }

    }
}
