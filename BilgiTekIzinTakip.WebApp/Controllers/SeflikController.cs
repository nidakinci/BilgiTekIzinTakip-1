﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BilgiTekIzinTakip.BusinessLayer;
using BilgiTekIzinTakip.Entities;
using BilgiTekIzinTakip.WebApp.Filters;
using BilgiTekIzinTakip.WebApp.Models;

namespace BilgiTekIzinTakip.WebApp.Controllers
{
    [Auth]
    public class SeflikController : Controller
    {
        private SeflikManager seflikManager = new SeflikManager();
        private BaskanlikManager baskanlikManager = new BaskanlikManager();
        private MudurlukManager mudurlukManager = new MudurlukManager();

        // GET: Seflik
        public ActionResult Index()
        {
            return View(seflikManager.List());
        }

        // GET: Seflik/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seflik seflik = seflikManager.Find(x => x.Id == id);
            if (seflik == null)
            {
                return HttpNotFound();
            }
            return View(seflik);
        }

        // GET: Seflik/Create
        public ActionResult Create()
        {
            ViewBag.BaskanlikId = new SelectList(baskanlikManager.List(), "Id", "Isim");
            ViewBag.MudurlukId = new SelectList(mudurlukManager.List(), "Id", "Isim");
            return View();
        }

        // POST: Seflik/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Seflik seflik)
        {
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("CreatedOn");
            if (ModelState.IsValid)
            {
                seflikManager.Insert(seflik);
                return RedirectToAction("Index");
            }

            return View(seflik);
        }

        // GET: Seflik/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seflik seflik = seflikManager.Find(x => x.Id == id);
            if (seflik == null)
            {
                return HttpNotFound();
            }
            ViewBag.BaskanlikId = new SelectList(baskanlikManager.List(), "Id", "Isim");
            ViewBag.MudurlukId = new SelectList(mudurlukManager.List(), "Id","Isim");
            return View(seflik);
        }

        // POST: Seflik/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Seflik seflik)
        {
            ModelState.Remove("ModifiedUsername");
            ModelState.Remove("CreatedOn");
            ModelState.Remove("Baskanlik.Isim");
            ModelState.Remove("Baskanlik.ModifiedUsername");
            ModelState.Remove("Mudurluk.Isim");
            ModelState.Remove("Mudurluk.ModifiedUsername");
            if (ModelState.IsValid)
            {
                Seflik sef = seflikManager.Find(x => x.Id == seflik.Id);
                sef.Isim = seflik.Isim;
                sef.BaskanlikId = seflik.Baskanlik.Id;
                sef.MudurlukId = seflik.Mudurluk.Id;
                seflikManager.Update(sef);
                return RedirectToAction("Index");
            }
            return View(seflik);
        }

      
    }
}
