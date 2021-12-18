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

        public IActionResult BlogListByWriter()
        {
            var value = bm.GetBlogListWithCategoryByWriter(1).Where(x => x.BlogStatus == true).ToList();
            return View(value);
        }
        public void GetCategoryList()
        {
            List<SelectListItem> CategoryValues = (from x in cm.ListAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.CategoryList = CategoryValues;
        }


        [HttpGet]
        public IActionResult BlogAdd()
        {
            GetCategoryList();
            return View();
        }
        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            BlogValidator kurallar = new BlogValidator();
            ValidationResult result = kurallar.Validate(p);
            if (result.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WriterID = 1;
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
            GetCategoryList();
            return View();
        }

        public IActionResult BlogDelete(int id)
        {
            var blogValue = bm.TGetById(id);
            bm.TRemove(blogValue);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult BlogUpdate(int id)
        {
            var BlogValue = bm.TGetById(id);
            GetCategoryList();
            return View(BlogValue);
        }
        [HttpPost]
        public IActionResult BlogUpdate(Blog blog)
        {
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(blog);
            if (results.IsValid)
            {
                var value = bm.TGetById(blog.BlogID);//eski değeri getirme
                blog.WriterID = 1;
                //blog.BlogID = value.BlogID; //frontend kısmından değiştirlmesin diye burda birdaha atama yaptım
                blog.BlogCreateDate = value.BlogCreateDate;//blogCreateDate değişmemesi için tekrar atama yaptım
                bm.TUpdate(blog);//update işlemi
                return RedirectToAction("BlogListByWriter");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            GetCategoryList();
            return View();
        }
    }
}
