using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using DataLayer;

namespace ShoppingMVC.Controllers {
    public class ItensController : Controller {
        private readonly ShoppingEntities _db = new ShoppingEntities();
        private readonly Lista _listaAtual;
        private readonly SelectList _produtosPicklist;

        public ItensController() {
            _listaAtual = _db.Listas.First(l => l.Aberta);
            _produtosPicklist = new SelectList(_db.Produtos.OrderBy(p => p.Nome), "ID", "Nome");
        }

        public ActionResult ProdutosPicklist(string produto) {
            ViewBag.Selecao = "Todos";
            var produtos = produto == null ? 
                _db.ProdutosPicklist(_listaAtual.ID).ToList() : 
                _db.ProdutosPicklist(_listaAtual.ID).Where(p => p.Produto.Contains(produto)).ToList();
            return View(produtos);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProdutosPicklist(List<ProdutoPicklist> produtos, string buttonType, string selecao) {
            ModelState.Clear();
            if (buttonType == "Salvar") {
                if (ModelState.IsValid) {
                    var adicionar = produtos.Where(p => p.Adicionar);
                    if (!adicionar.Any())
                        return RedirectToAction("Index");

                    foreach (var produto in adicionar) {
                        _db.Itens.Add(new Item() {
                            ListaID = _listaAtual.ID,
                            ProdutoID = produto.ID,
                            QtdPrevista = produto.QtdNormal
                        });
                    }
                    _db.SaveChanges();
                    return RedirectToAction("ProdutosPicklist", "Itens");
                }
                else {
                    return RedirectToAction("Index");
                }
            }

            else if (buttonType == "Todos os produtos") {
                var novalista = _db.ProdutosPicklist(_listaAtual.ID).ToList();
                foreach (var produto in produtos.Where(p => p.Adicionar)) {
                    novalista.Find(p => p.ID == produto.ID).Adicionar = true;
                }
                ViewBag.Selecao = "Todos";
                return View(novalista);
            }

            else if (buttonType == "Lista Padrão") {
                var novalista = _db.ProdutosPicklist(_listaAtual.ID).Where(p => p.ListaPadrao).ToList();
                if (selecao == "Todos") {
                    foreach (var produto in produtos.Where(p => p.Adicionar)) {
                        novalista.Find(p => p.ID == produto.ID).Adicionar = true;
                    }
                }
                ViewBag.Selecao = "Padrao";
                return View(novalista);
            }

            else if (buttonType == "Eventuais") {
                var novalista = _db.ProdutosPicklist(_listaAtual.ID).Where(p => !p.ListaPadrao).ToList();
                if (selecao == "Todos") {
                    foreach (var produto in produtos.Where(p => p.Adicionar)) {
                        novalista.Find(p => p.ID == produto.ID).Adicionar = true;
                    }
                }
                ViewBag.Selecao = "Eventuais";
                return View(novalista);
            }

            else if (buttonType == "Marcar Lista Padrão") {
                foreach (var produto in produtos) {
                    produto.Adicionar = produto.Adicionar || produto.ListaPadrao;
                }
                ViewBag.Selecao = selecao;
                return View(produtos);
            }

            else if (buttonType == "Marcar todos" || buttonType == "Desmarcar todos") {
                var marcar = buttonType == "Marcar todos";
                foreach (var produto in produtos) {
                    produto.Adicionar = marcar;
                }
                ViewBag.Selecao = selecao;
                return View(produtos);
            }

            else {
                ViewBag.Selecao = selecao;
                return View(produtos);
            }
        }
        
        public ActionResult Close() {
            _listaAtual.Aberta = false;
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        // GET: Items
        public ActionResult Index() {
            var itens = _db.Itens.Where(i => i.ListaID == _listaAtual.ID)
                .Include(i => i.Lista).Include(i => i.Produto).OrderBy(i => i.Produto.Nome).ToList();
            if (itens.Any()) {
                return View(itens);
            }
            else {
                return RedirectToAction("ProdutosPicklist", "Itens");
            }
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = _db.Itens.Find(id);
            if (item == null) {
                return HttpNotFound();
            }
            return View(item);
        }

        public ActionResult EditMulti() {
            ViewBag.ProdutoID = _produtosPicklist;
            var lista = _db.Listas.First(l => l.Aberta);
            var itens = _db.Itens.Where(i => i.ListaID == lista.ID)
                .Include(i => i.Lista).Include(i => i.Produto).OrderBy(i => i.Produto.Nome);
            return View(itens.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMulti(List<Item> itens) {
            if (ModelState.IsValid) {
                foreach (var item in itens) {
                    item.ListaID = _listaAtual.ID;
                    _db.Entry(item).State = EntityState.Modified;
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else {
                return RedirectToAction("Index");
            }
        }

        private SelectList ProdutosDisponiveis() {
            return new SelectList(_db.ProdutosPicklist(_listaAtual.ID).OrderBy(p => p.Produto), "ID", "Produto");
        }

        // GET: Items/Create
        public ActionResult Create() {
            ViewBag.ProdutoID = ProdutosDisponiveis();
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProdutoID,QtdPrevista,QtdReal,Marca,Preco")] Item item) {
            if (ModelState.IsValid) {
                item.ListaID = _listaAtual.ID;
                _db.Itens.Add(item);
                _db.SaveChanges();
                //return RedirectToAction("Index");
                return Redirect(Request.UrlReferrer.ToString());
            }

            ViewBag.ProdutoID = ProdutosDisponiveis();
            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = _db.Itens.Find(id);
            if (item == null) {
                return HttpNotFound();
            }
            ViewBag.ProdutoID = _produtosPicklist;
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProdutoID,QtdPrevista,QtdReal,Marca,Preco")] Item item) {
            item.ListaID = _listaAtual.ID;
            if (ModelState.IsValid) {
                _db.Entry(item).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoID = new SelectList(_db.Produtos, "ID", "Nome", item.ProdutoID);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id) {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = _db.Itens.Find(id);
            if (item == null) {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            Item item = _db.Itens.Find(id);
            _db.Itens.Remove(item);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
