using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreDemo.Areas.Admin.Controllers
{
    public class WriterController : Controller
    {
        [Area("Admin")]

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            var JsonWriters = JsonConvert.SerializeObject(Writers);
            return Json(JsonWriters);
        }
        public IActionResult GetWriterByID(int writerId)
        {
            var findWriter = Writers.FirstOrDefault(x => x.Id == writerId);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }
        [HttpPost]
        public IActionResult AddWriter(WriterClass w)
        {
            Writers.Add(w);
            var jsonWriters = JsonConvert.SerializeObject(w);
            return Json(jsonWriters);
        }
        [HttpPost]
        public IActionResult DeleteWriter(int id)
        {
            var writer = Writers.FirstOrDefault(x => x.Id == id);
            Writers.Remove(writer);
            return Json(writer);
            //return Ok(); // Bu da dönebilirdi
        }
        public IActionResult UpdateWriter(WriterClass writerModel)
        {
            var writer = Writers.FirstOrDefault(x => x.Id == writerModel.Id);
            writer.Name = writerModel.Name;
            var jsonWriter = JsonConvert.SerializeObject(writerModel);
            return Json(jsonWriter);
        }
        public static List<WriterClass> Writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id=1,
                Name="Burak"
            },
            new WriterClass
            {
                Id=2,
                Name="Murat"
            },
            new WriterClass
            {
                Id=3,
                Name="Buse"
            }
        };
    }
}
