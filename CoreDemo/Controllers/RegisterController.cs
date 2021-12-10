using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        RegisterCity cm = new RegisterCity();

        [HttpGet]
        public IActionResult Index()
        {
            List<SelectListItem> deger1 = (from x in cm.RegisterCities()
                                           select new SelectListItem
                                           {
                                               Text = x.CityName,   //optionun metni
                                               Value = x.CityName //optionun valuesi
                                           }).ToList();
            ViewBag.dpr = deger1;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Writer p)
        {
            WriterValidator kurallar = new WriterValidator();
            ValidationResult result = kurallar.Validate(p);
            if (result.IsValid)
            {
                p.WriterStatus = true;
                p.WriterAbout = "Deneme Test";
                wm.WriterAdd(p);
                return RedirectToAction("Index", "Blog");
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
