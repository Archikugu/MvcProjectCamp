using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProjectCamp.Controllers
{
    public class MessageController : Controller
    {
        Context _context = new Context();
        ContactManager contactManager = new ContactManager(new EfContactDal());
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public IActionResult Inbox()
        {
            var messageList = messageManager.GetListInbox();
            return View(messageList);
        }
        public IActionResult Sendbox()
        {
            var messagelist = messageManager.GetSendInbox();
            return View(messagelist);
        }
        [HttpGet]
        public IActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewMessage(Message message)
        {

            return View();
        }
    }
}
