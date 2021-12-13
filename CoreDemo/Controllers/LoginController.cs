using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Index(Writer p)
        {
            Context c = new Context(); 
            var datavalue = c.Writers.FirstOrDefault(x=>x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword); 
            if (datavalue != null)
            {
                HttpContext.Session.SetString("Username", p.WriterMail);
                return RedirectToAction("Index","Blog");
            }
            else
            {
                return View();
            }            
        }

    }
}
