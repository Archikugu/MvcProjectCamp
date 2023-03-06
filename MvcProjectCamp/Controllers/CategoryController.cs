using Microsoft.AspNetCore.Mvc;

namespace MvcProjectCamp.Controllers {
    public class CategoryController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
