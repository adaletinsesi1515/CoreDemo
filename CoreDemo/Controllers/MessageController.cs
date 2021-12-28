using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        Context c = new Context();
        public IActionResult InBox()
        {
            var usermail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();            
            var values = mm.GetInboxListByWriter(writerId);
            return View(values);
        }
                
        public IActionResult MessageDetails(int id)
        {
            var details = mm.TGetById(id);
            return View(details);
        }
    }
}
