using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page=1)
        {
            var value = cm.ListAll().ToPagedList(page, 3);
            return View(value);
        }

        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(p);
            if (results.IsValid)
            {
                p.CategoryStatus = true;
                cm.TAdd(p);
                return RedirectToAction("Index");

            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult CategoryPassive(int id)
        {
            var value=cm.TGetById(id);
            value.CategoryStatus = false;            
            cm.TUpdate(value);            
            return RedirectToAction("Index");
        }

        public IActionResult CategoryActive(int id)
        {
            var value = cm.TGetById(id);
            value.CategoryStatus = true;
            cm.TUpdate(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CategoryEdit(int id)
        {
            var values = cm.TGetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult CategoryEdit (Category p)
        {
            CategoryValidator bv = new CategoryValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                var value = cm.TGetById(p.CategoryID);//eski değeri getirme
                cm.TUpdate(p);//update işlemi
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }            
            return View();
        }

    }
}
