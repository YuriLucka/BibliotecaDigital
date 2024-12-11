using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BibliotecaDigital.DAL;
using BibliotecaDigital.Models;

namespace BibliotecaDigital.Controllers
{
    public class LivroController : Controller
    {
        private BibliotecaDigitalContext db = new BibliotecaDigitalContext();

        // GET: Livro
        public ActionResult Index()
        {
            var livros = db.Livros.Include(l => l.Autor).Include(l => l.Categoria);
            return View(livros.ToList());
        }

        // GET: Livro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        // GET: Livro/Create
        public ActionResult Create()
        {
            ViewBag.AutorID = new SelectList(db.Autores, "ID", "Nome");
            ViewBag.CategoriaID = new SelectList(db.Categorias, "ID", "Nome");
            return View();
        }

        // POST: Livro/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titulo,Descricao,CategoriaID,AutorID,UrlCapa,Status,NumeroDePaginas,PaginaAtual")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                db.Livros.Add(livro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AutorID = new SelectList(db.Autores, "ID", "Nome", livro.AutorID);
            ViewBag.CategoriaID = new SelectList(db.Categorias, "ID", "Nome", livro.CategoriaID);
            return View(livro);
        }

        // GET: Livro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            ViewBag.AutorID = new SelectList(db.Autores, "ID", "Nome", livro.AutorID);
            ViewBag.CategoriaID = new SelectList(db.Categorias, "ID", "Nome", livro.CategoriaID);
            return View(livro);
        }

        // POST: Livro/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titulo,Descricao,CategoriaID,AutorID,UrlCapa,Status,NumeroDePaginas,PaginaAtual")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(livro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AutorID = new SelectList(db.Autores, "ID", "Nome", livro.AutorID);
            ViewBag.CategoriaID = new SelectList(db.Categorias, "ID", "Nome", livro.CategoriaID);
            return View(livro);
        }

        // GET: Livro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Livro livro = db.Livros.Find(id);
            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }

        // POST: Livro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Livro livro = db.Livros.Find(id);
            db.Livros.Remove(livro);
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
