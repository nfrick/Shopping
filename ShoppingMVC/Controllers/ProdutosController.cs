﻿using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DataLayer;

namespace ShoppingMVC.Controllers {
    public class ProdutosController : Controller {
        private ShoppingEntities db = new ShoppingEntities();

        // GET: Produtos
        public ActionResult Index() {
            var produtos = db.Produtos.Include(p => p.Categoria);
            return View(produtos.OrderBy(p => p.Nome).ToList());
        }

        public ActionResult IndexPorCategoria() {
            var produtos = db.Produtos.Include(p => p.Categoria);
            return View(produtos.GroupBy(p => p.Categoria.Nome).ToList());
        }


        // GET: Produtos/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null) {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create() {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "ID", "Nome");
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CategoriaID,Nome,Unidade,QtdNormal,MarcasSim,MarcasNao,ListaPadrao")] Produto produto) {
            if (ModelState.IsValid) {
                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "ID", "Nome", produto.CategoriaID);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null) {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "ID", "Nome", produto.CategoriaID);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CategoriaID,Nome,Unidade,QtdNormal,MarcasSim,MarcasNao,ListaPadrao")] Produto produto) {
            if (ModelState.IsValid) {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "ID", "Nome", produto.CategoriaID);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null) {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
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
