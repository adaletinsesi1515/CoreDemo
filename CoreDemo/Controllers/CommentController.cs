using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PartialAddComment()
        {
            return PartialView();
        }

        public IActionResult CommentListByBlog(int id)
        {
            var values = cm.ListAll(id);
            return PartialView(values);
        }



    }
}
