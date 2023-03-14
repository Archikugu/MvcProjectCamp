using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace MvcProjectCamp.Controllers {
    public class WriterController : Controller {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();

        public IActionResult Index() {
            var writerValues = writerManager.GetList();
            return View(writerValues);
        }
        [HttpGet]
        public IActionResult AddWriter() {
            return View();
        }
        [HttpPost]
        public IActionResult AddWriter(Writer writer) {
            ValidationResult result = writerValidator.Validate(writer);
            if (result.IsValid) {
                writerManager.WriterAdd(writer);
                return RedirectToAction("Index");
            }
            else {
                foreach (var item in result.Errors) {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult EditWriter(int id) {
            var writerValue = writerManager.GetById(id);
            return View(writerValue);
        }
        [HttpPost]
        public IActionResult EditWriter(Writer writer) {
            ValidationResult result = writerValidator.Validate(writer);
            if (result.IsValid) {
                writerManager.WriterUpdate(writer);
                return RedirectToAction("Index");
            }
            else {
                foreach (var item in result.Errors) {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
