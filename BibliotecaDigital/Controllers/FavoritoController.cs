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
    public class FavoritoController : Controller
    {
        private BibliotecaDigitalContext db = new BibliotecaDigitalContext();

        // GET: Favorito
        public ActionResult Index()
        {
            var favoritoes = db.Favoritoes.Include(f => f.Livro).Include(f => f.Usuario);
            return View(favoritoes.ToList());
        }

        // GET: Favorito/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favorito favorito = db.Favoritoes.Find(id);
            if (favorito == null)
            {
                return HttpNotFound();
            }
            return View(favorito);
        }

        // GET: Favorito/Create
        public ActionResult Create()
        {
            ViewBag.LivroID = new SelectList(db.Livros, "ID", "Titulo");
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "ID", "NomeUsuario");
            return View();
        }

        // POST: Favorito/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UsuarioID,LivroID")] Favorito favorito)
        {
            if (ModelState.IsValid)
            {
                db.Favoritoes.Add(favorito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LivroID = new SelectList(db.Livros, "ID", "Titulo", favorito.LivroID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "ID", "NomeUsuario", favorito.UsuarioID);
            return View(favorito);
        }

        // GET: Favorito/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favorito favorito = db.Favoritoes.Find(id);
            if (favorito == null)
            {
                return HttpNotFound();
            }
            ViewBag.LivroID = new SelectList(db.Livros, "ID", "Titulo", favorito.LivroID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "ID", "NomeUsuario", favorito.UsuarioID);
            return View(favorito);
        }

        // POST: Favorito/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UsuarioID,LivroID")] Favorito favorito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(favorito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LivroID = new SelectList(db.Livros, "ID", "Titulo", favorito.LivroID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "ID", "NomeUsuario", favorito.UsuarioID);
            return View(favorito);
        }

        // GET: Favorito/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favorito favorito = db.Favoritoes.Find(id);
            if (favorito == null)
            {
                return HttpNotFound();
            }
            return View(favorito);
        }

        // POST: Favorito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Favorito favorito = db.Favoritoes.Find(id);
            db.Favoritoes.Remove(favorito);
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
