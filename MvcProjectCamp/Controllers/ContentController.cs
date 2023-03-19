using Business.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcProjectCamp.Controllers {
    public class ContentController : Controller {

        ContentManager contentManager = new ContentManager(new EfContentDal());
        public IActionResult Index() {
            return View();
        }
        public IActionResult ContentByHeading(int id) {
            var contentValues = contentManager.GetListByHeadingId(id);
            return View(contentValues);
        }
    }

}
