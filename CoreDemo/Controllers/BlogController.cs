using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public IActionResult Index()
        {
            var values = bm.GetBlogListWithCategory();
            return View(values);
        }

        public IActionResult BlogReadAll(int id)
        {
            ViewBag.Id = id;
            var values = bm.ListAllParameter(id);
            return View(values);
        }

        public IActionResult BlogListByWriter ()
        {
            var value = bm.GetBlogListByWriter(1);
            return View(value);
        }


        [HttpGet]
        public IActionResult BlogAdd()
        {
            ViewBag.Category = cm.ListAll().Select(x=> 
                                new SelectListItem { Text = x.CategoryName, 
                                                      Value = x.CategoryID.ToString()}).ToList();
                     

            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            BlogValidator kurallar = new BlogValidator();
            ValidationResult result = kurallar.Validate(p);
            if (result.IsValid)
            {
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.BlogStatus = true;                
                p.WriterID = 1;

                //List<SelectListItem> categorikayit = (from i in cm.ListAll()
                //                                      select new SelectListItem
                //                                      {
                //                                          Text = i.CategoryName,
                //                                          Value = i.CategoryID.ToString(),
                //                                      }).ToList();
                //ViewBag.dgr1 = categorikayit;

                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

    }
}
