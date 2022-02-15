using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreDemo.Controllers
{
    public class TestEmployeeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var responseMessage = await httpClient.GetAsync("https://localhost:44319/api/Default");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<List<Class1>>(jsonString);
            return View(value);
        }

        public class Class1
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }




    }
}
