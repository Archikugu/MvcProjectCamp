using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcProjectCamp.Controllers {
    public class CategoryController : Controller {
        CategoryManager manager = new CategoryManager(new EfCategoryDal());
        public IActionResult Index() {
            return View();
        }
        public IActionResult GetCategoryList() {
            var categoryValues = manager.GetCategoryList();
            return View(categoryValues);
        }
        [HttpGet]
        public IActionResult AddCategory() {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category) {
            //manager.Add(category);
            return RedirectToAction("GetCategoryList");
        }
    }
}
