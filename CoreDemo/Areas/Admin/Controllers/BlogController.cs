using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.open.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }
            }            
        }

        public List<BlogModel> GetBlogList ()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel { ID = 1, BlogName = "C# Programlamaya Giriş"},
                new BlogModel { ID = 2, BlogName = "Tesla Firmasının araçları"},
                new BlogModel { ID = 3, BlogName = "2020 yılı Olimpiyatları"},
            };
            return bm;
        }

        public IActionResult BlogListExcel()
        {
            return View();
        }
    }
}
