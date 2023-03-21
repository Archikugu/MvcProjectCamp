using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MvcProjectCamp.Controllers {
    public class ContactController : Controller {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator validationRules = new ContactValidator();
        public IActionResult Index() {
            var contactValus = contactManager.GetContactList();
            return View(contactValus);
        }
        public IActionResult GetContactDetails(int id) {
            var contactValue = contactManager.GetById(id);
            return View(contactValue);
        }

        public PartialViewResult MessageListMenu() {
            return PartialView();
        }

    }
}
