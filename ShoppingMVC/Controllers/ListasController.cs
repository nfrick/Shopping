using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DataLayer;

namespace ShoppingMVC.Controllers {
    public class ListasController : Controller {
        private ShoppingEntities db = new ShoppingEntities();

        // GET: Listas
        public ActionResult Index() {
            var listas = db.Listas.Include(l => l.Loja).OrderByDescending(l => l.Data);
            ViewBag.ExisteListaAberta = db.Listas.Any(l => l.Aberta);
            return View(listas.ToList());
        }

        public ActionResult AbrirLista(int? id) {
            return ListaAbrirFechar(id, true);
        }

        public ActionResult FecharLista(int? id) {
            return ListaAbrirFechar(id, false);
        }

        private ActionResult ListaAbrirFechar(int? id, bool abrir) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lista = db.Listas.Find(id);
            if (lista == null) {
                return HttpNotFound();
            }
            lista.Aberta = abrir;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GoToItens() {
            return RedirectToAction("Index", "Itens");
        }

        // GET: Listas/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lista = db.Listas.Find(id);
            if (lista == null) {
                return HttpNotFound();
            }
            return View(lista);
        }

        // GET: Listas/Create
        public ActionResult Create() {
            ViewBag.LojaID = new SelectList(db.Lojas, "ID", "Nome");
            return View();
        }

        // POST: Listas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Data,Descricao,LojaID")] Lista lista) {
            if (ModelState.IsValid) {
                lista.Aberta = true;
                db.Listas.Add(lista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LojaID = new SelectList(db.Lojas, "ID", "Nome", lista.LojaID);
            return View(lista);
        }

        // GET: Listas/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista lista = db.Listas.Find(id);
            if (lista == null) {
                return HttpNotFound();
            }
            ViewBag.LojaID = new SelectList(db.Lojas, "ID", "Nome", lista.LojaID);
            return View(lista);
        }

        // POST: Listas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Data,Descricao,LojaID, Aberta")] Lista lista) {
            if (ModelState.IsValid) {
                db.Entry(lista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LojaID = new SelectList(db.Lojas, "ID", "Nome", lista.LojaID);
            return View(lista);
        }

        // GET: Listas/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lista lista = db.Listas.Find(id);
            if (lista == null) {
                return HttpNotFound();
            }
            return View(lista);
        }

        // POST: Listas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Lista lista = db.Listas.Find(id);
            db.Listas.Remove(lista);
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
