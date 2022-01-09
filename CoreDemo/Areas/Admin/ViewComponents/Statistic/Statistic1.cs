using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        ContactManager cm = new ContactManager(new EfContactRepository());
        CommentManager ccm = new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = bm.ListAll().Count();
            ViewBag.v2 = cm.ListAll().Count();
            ViewBag.v3 = ccm.ListAll().Count();
            return View();
        }

    }
}
