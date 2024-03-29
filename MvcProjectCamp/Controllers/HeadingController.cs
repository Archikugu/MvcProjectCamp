﻿using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProjectCamp.Controllers {
    public class HeadingController : Controller {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        public IActionResult Index() {
            var headingValues = headingManager.GetList();
            return View(headingValues);
        }
        [HttpGet]
        public IActionResult AddHeading() {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetCategoryList()
                                                  select new SelectListItem { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList();
            ViewBag.valueCategory = valueCategory;

            List<SelectListItem> valueWriter = (from x in writerManager.GetList()
                                                select new SelectListItem { Text = x.WriterName + " " + x.WriterSurName, Value = x.WriterId.ToString() }).ToList();
            ViewBag.valueWriter = valueWriter;


            return View();
        }
        [HttpPost]
        public IActionResult AddHeading(Heading p) {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToString());
            headingManager.HeadingAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditHeading(int id) {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetCategoryList()
                                                  select new SelectListItem { Text = x.CategoryName, Value = x.CategoryId.ToString() }).ToList();
            ViewBag.valueCategory = valueCategory;
            var headingValues = headingManager.GetById(id);
            return View(headingValues);
        }
        [HttpPost]
        public IActionResult EditHeading(Heading heading) {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteHeading(int id) {
            var headingValue = headingManager.GetById(id);
            if (headingValue.HeadingStatus == true) {
                headingValue.HeadingStatus = false;
            }
            else if (headingValue.HeadingStatus == false) {
                headingValue.HeadingStatus = true;
            }
            headingManager.HeadingDelete(headingValue);
            return RedirectToAction("Index");
        }

    }
}
