﻿using BanSach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BanSach.Controllers
{

    public class BannerController : Controller
    {
        private readonly db_Book db = new db_Book();

        // GET: Banners (Hiển thị danh sách banner)
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public PartialViewResult Banners()
        {
            var banners = db.Banner.ToList();
            return PartialView(banners);
        }

        public ActionResult Index()
        {
            var banners = db.Banner.ToList();
            return View(banners);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Banner/Create (Thực hiện thêm mới banner)
        [HttpPost]
        public ActionResult Create(Banner banner)
        {
            if (ModelState.IsValid)
            {
                db.Banner.Add(banner);
                db.SaveChanges();
                return RedirectToAction("Index");  // Điều hướng lại về danh sách banner
            }
            return View(banner);
        }

        // GET: Banner/Edit/{id} (Hiển thị form sửa banner)
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var banner = db.Banner.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }
            return View(banner);
        }

        // POST: Banner/Edit/{id} (Thực hiện sửa banner)
        [HttpPost]
        public ActionResult Edit(Banner banner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(banner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");  // Điều hướng lại về danh sách banner
            }
            return View(banner);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var banner = db.Banner.Find(id);
            if (banner == null)
            {
                return HttpNotFound();
            }

            db.Banner.Remove(banner);
            db.SaveChanges();
            return Json(new { success = true });
        }
    }
}
