using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MvcProjectCamp.Controllers {
    public class HeadingController : Controller {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        public IActionResult Index() {
            var headingValues = headingManager.GetList();
            return View(headingValues);
        }
        [HttpGet]
        public IActionResult AddHeading() {
            return View();
        }
        [HttpPost]
        public IActionResult AddHeading(Heading p) {
            headingManager.HeadingAdd(p);
            return RedirectToAction("Index");
        }
    }
}
