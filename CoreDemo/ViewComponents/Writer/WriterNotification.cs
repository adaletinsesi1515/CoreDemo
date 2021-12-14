using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        WriterManager wm = new WriterManager(new EfWriterRepository()); 
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
