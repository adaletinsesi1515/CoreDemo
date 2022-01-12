using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm = new BlogManager(new EfBlogRepository());
        ContactManager cm = new ContactManager(new EfContactRepository());
        CommentManager ccm = new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = bm.ListAll().Count();
            ViewBag.v2 = cm.ListAll().Count();
            ViewBag.v3 = ccm.ListAll().Count();

            //Hava durumunu API üzerinden çekme işlemi (Türkçe dil desteği var)
            string api_key = "b3de9d0a7f8f915aec4b674625194dcc";
            string connection = "http://api.openweathermap.org/data/2.5/weather?q=Burdur&mode=xml&units=metric&lang=tr&appid=" + api_key;
            XDocument document = XDocument.Load(connection);
            //Derece bilgisi
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            //Bulut - Güneş bilgisi
            ViewBag.v5 = document.Descendants("clouds").ElementAt(0).Attribute("name").Value;


            return View();
        }

    }
}
