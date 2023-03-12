using Microsoft.AspNetCore.Mvc;

namespace MvcProjectCamp.Controllers {
    public class AdminCategoryController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
