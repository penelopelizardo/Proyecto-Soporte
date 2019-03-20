﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinanzasPersonalesWeb.Models;

namespace FinanzasPersonalesWeb.Controllers
{
    public class MonedasController : Controller
    {
        private Model1 db = new Model1();

        // GET: Monedas
        public ActionResult Index()
        {
            return View(db.Monedas.ToList());
        }

        // GET: Monedas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monedas monedas = db.Monedas.Find(id);
            if (monedas == null)
            {
                return HttpNotFound();
            }
            return View(monedas);
        }

        // GET: Monedas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Monedas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MonedaId,MonedaDescripcion,MonedaSimbolo")] Monedas monedas)
        {
            if (ModelState.IsValid)
            {
                db.Monedas.Add(monedas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(monedas);
        }

        // GET: Monedas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monedas monedas = db.Monedas.Find(id);
            if (monedas == null)
            {
                return HttpNotFound();
            }
            return View(monedas);
        }

        // POST: Monedas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MonedaId,MonedaDescripcion,MonedaSimbolo")] Monedas monedas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(monedas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(monedas);
        }

        // GET: Monedas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monedas monedas = db.Monedas.Find(id);
            if (monedas == null)
            {
                return HttpNotFound();
            }
            return View(monedas);
        }

        // POST: Monedas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Monedas monedas = db.Monedas.Find(id);
            db.Monedas.Remove(monedas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
