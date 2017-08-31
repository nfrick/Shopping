using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using Newtonsoft.Json;

namespace ShoppingMVC.Controllers {
    public class LojasController : Controller {
        private ShoppingEntities db = new ShoppingEntities();

        // GET: Lojas
        public ActionResult Index() {
            return View(db.Lojas.OrderBy(l=>l.Nome).ToList());
        }

        // GET: Lojas/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loja loja = db.Lojas.Find(id);
            if (loja == null) {
                return HttpNotFound();
            }
            return View(loja);
        }

        // GET: Lojas/Create
        public ActionResult Create() {
            throw new StackOverflowException();
            return View();
        }

        // POST: Lojas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Latitude,Longitude")] Loja loja) {
            if (ModelState.IsValid) {
                db.Lojas.Add(loja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loja);
        }

        // GET: Lojas/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loja loja = db.Lojas.Find(id);
            if (loja == null) {
                return HttpNotFound();
            }
            return View(loja);
        }

        // POST: Lojas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nome,Latitude,Longitude")] Loja loja) {
            if (ModelState.IsValid) {
                db.Entry(loja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loja);
        }

        // GET: Lojas/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loja loja = db.Lojas.Find(id);
            if (loja == null) {
                return HttpNotFound();
            }
            return View(loja);
        }

        // POST: Lojas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Loja loja = db.Lojas.Find(id);
            db.Lojas.Remove(loja);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
