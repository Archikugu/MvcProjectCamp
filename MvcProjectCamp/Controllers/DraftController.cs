using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MvcProjectCamp.Controllers
{
    public class DraftController : Controller
    {
        DraftManager draftManager = new DraftManager(new EfDraftDal());
        public ActionResult Index()
        {
            var draftValues = draftManager.GetList();
            return View(draftValues);
        }

        public ActionResult GetDraftDetails(int id)
        {
            var draftValue = draftManager.GetByID(id);
            return View(draftValue);
        }

        [HttpGet]
        public ActionResult AddDraft()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDraft(Draft draft)
        {
            draft.DraftDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            draftManager.DraftAdd(draft);
            return RedirectToAction("Index");
        }
    }
}
