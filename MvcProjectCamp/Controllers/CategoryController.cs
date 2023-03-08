using Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcProjectCamp.Controllers {
    public class CategoryController : Controller {
        CategoryManager manager = new CategoryManager();
        public IActionResult Index() {
            return View();
        }
        public IActionResult GetCategoryList() {
            var categoryValues = manager.GetAll();
            return View(categoryValues);
        }
    }
}
