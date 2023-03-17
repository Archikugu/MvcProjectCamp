using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Xml.Linq;

namespace MvcProjectCamp.Controllers {
    public class StatisticsController : Controller {

        Context _context = new Context();
        public ActionResult Index() {
            //Toplam Kategori Sayisi
            var totalCategoryCount = _context.Categories.Count(); 
            ViewBag.TotalCategoryCount = totalCategoryCount;

            //Başlık tablosunda "Yazılım" kategorisine ait başlık sayısı
            var numberOfTitlesBelongingToTheSoftwareCategory = _context.Headings.Where(u => u.Category.CategoryName == "Yazılım").Count();
            ViewBag.numberOfTitlesBelongingToTheSoftwareCategory = numberOfTitlesBelongingToTheSoftwareCategory;

            // Yazar adinda "a" harfi gecen yazar sayisi
            var numberOfWritersWithALetterInTheWriterName = _context.Writers.Count(x => x.WriterName.Contains("a")); 
            ViewBag.numberOfWritersWithALetterInTheWriterName = numberOfWritersWithALetterInTheWriterName;

            // En fazla basliga sahip kategori adi
            var categoryNamesWithTheMostTitles = _context.Headings.Where(u => u.CategoryId == _context.Headings.GroupBy(x => x.CategoryId).OrderByDescending(x => x.Count())
                .Select(x => x.Key).FirstOrDefault()).Select(x => x.Category.CategoryName).FirstOrDefault(); // En fazla basliga sahip kategori adi
            ViewBag.categoryNamesWithTheMostTitles = categoryNamesWithTheMostTitles;

            // Kategoriler tablosundaki aktif kategori sayisi
            var categoryStatusTrue = _context.Categories.Count(x => x.CategoryStatus == true); 
            ViewBag.ActiveCategory = categoryStatusTrue;

            return View();
        }

    }
}
