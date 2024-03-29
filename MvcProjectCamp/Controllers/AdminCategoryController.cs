﻿using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace MvcProjectCamp.Controllers {
    public class AdminCategoryController : Controller {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        public IActionResult Index() {
            var categoryValues = categoryManager.GetCategoryList();
            return View(categoryValues);
        }
        [HttpGet]
        public IActionResult AddCategory() {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category) {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult result = categoryValidator.Validate(category);
            if (result.IsValid) {
                categoryManager.CategoryAdd(category);
                return RedirectToAction("Index");
            }
            else {
                foreach (var item in result.Errors) {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public IActionResult DeleteCategory(int id) {
            var categoryValue = categoryManager.GetById(id);
            categoryManager.CategoryDelete(categoryValue);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCategory(int id) {
            var categoryValue = categoryManager.GetById(id);
            return View(categoryValue);
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category category) {
            categoryManager.CategoryUpdate(category);
            return RedirectToAction("Index");
        }
    }
}
