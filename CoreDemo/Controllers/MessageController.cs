using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        public IActionResult InBox()
        {
            int id= 2;
            var values = mm.GetInboxListByWriter(id);
            return View(values);
        }
                
        public IActionResult MessageDetails(int id)
        {
            var details = mm.TGetById(id);
            return View(details);
        }
    }
}
