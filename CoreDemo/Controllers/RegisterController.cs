using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDemo.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        RegisterCity cm = new RegisterCity();

        [AllowAnonymous]
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
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(AddProfileImage p, Writer x)
        {
            WriterValidator kurallar = new WriterValidator();
            ValidationResult result = kurallar.Validate(x);
            if (result.IsValid)
            {
                if (p.WriterImage != null)
                {
                    var extension = Path.GetExtension(p.WriterImage.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/",
                        newImageName);
                    var stream = new FileStream(location, FileMode.Create);
                    p.WriterImage.CopyTo(stream);
                    x.WriterImage = newImageName;
                }
                x.WriterName = p.WriterName;
                x.WriterAbout = p.WriterAbout;
                x.WriterMail = p.WriterMail;
                x.WriterPassword = p.WriterPassword;
                x.WriterPassword2 = p.WriterPassword2;
                x.WriterStatus = true;
                wm.TAdd(x);
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
