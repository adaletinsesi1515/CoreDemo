using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using CoreDemo.Models;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        Context c = new Context();

        [Authorize]
        public IActionResult Index()
        {
            var usermail = User.Identity.Name;
            ViewBag.usermaildata = usermail;
                        
            var username = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.usernamedata = username;
            return View();
        }

        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }

        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            var usermail = User.Identity.Name;
            var writerId= c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = wm.TGetById(writerId);
            return View(values);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(AddProfileImage p, Writer x)
        {            
            WriterValidator wl = new WriterValidator();
            ValidationResult result = wl.Validate(x);
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
                wm.TUpdate(x);
                return RedirectToAction("Index", "Dashboard");
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
