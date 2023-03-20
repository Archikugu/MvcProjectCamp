using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcProjectCamp.Controllers {
    public class AboutController : Controller {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        public IActionResult Index() {
            var aboutValues = aboutManager.GetAboutList();
            return View(aboutValues);
        }
        [HttpGet]
        public IActionResult AddAbout() {
            return View();
        }
        [HttpPost]
        public IActionResult AddAbout(About about) {
            aboutManager.AboutAdd(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial() {
            return PartialView();
        }
    }
}
