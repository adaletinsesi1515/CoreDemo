using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        MessageManager mm = new MessageManager(new EfMessageRepository()); 

        public IViewComponentResult Invoke()
        {
            int id = 2;            
            var values = mm.GetInboxListByWriter(id);
            return View(values);  
        }

    }
}
