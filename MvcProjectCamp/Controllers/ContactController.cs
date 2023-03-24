using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProjectCamp.Controllers
{
    public class ContactController : Controller
    {
        Context _context = new Context();
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        ContactValidator validationRules = new ContactValidator();
        public IActionResult Index()
        {
            var contactValus = contactManager.GetContactList();
            return View(contactValus);
        }
        public IActionResult GetContactDetails(int id)
        {
            var contactValue = contactManager.GetById(id);
            return View(contactValue);
        }

        public async Task<PartialViewResult> MessageListMenu()
        {
            var receiverMail = _context.Messages.Count(m => m.ReceiverMail == "admin@gmail.com").ToString();
            ViewBag.receiverMail = receiverMail;

            var senderMail = _context.Messages.Count(m => m.SenderMail == "admin@gmail.com").ToString();
            ViewBag.senderMail = senderMail;
            return PartialView("~/Views/Contact/MessageListMenu.cshtml");
        }

    }
}
