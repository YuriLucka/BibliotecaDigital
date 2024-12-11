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
    public class ComentarioController : Controller
    {
        private BibliotecaDigitalContext db = new BibliotecaDigitalContext();

        // GET: Comentario
        public ActionResult Index()
        {
            var comentarios = db.Comentarios.Include(c => c.Livro).Include(c => c.Usuario);
            return View(comentarios.ToList());
        }

        // GET: Comentario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentarios.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // GET: Comentario/Create
        public ActionResult Create()
        {
            ViewBag.LivroID = new SelectList(db.Livros, "ID", "Titulo");
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "ID", "NomeUsuario");
            return View();
        }

        // POST: Comentario/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UsuarioID,LivroID,Texto")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Comentarios.Add(comentario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LivroID = new SelectList(db.Livros, "ID", "Titulo", comentario.LivroID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "ID", "NomeUsuario", comentario.UsuarioID);
            return View(comentario);
        }

        // GET: Comentario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentarios.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            ViewBag.LivroID = new SelectList(db.Livros, "ID", "Titulo", comentario.LivroID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "ID", "NomeUsuario", comentario.UsuarioID);
            return View(comentario);
        }

        // POST: Comentario/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UsuarioID,LivroID,Texto")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comentario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LivroID = new SelectList(db.Livros, "ID", "Titulo", comentario.LivroID);
            ViewBag.UsuarioID = new SelectList(db.Usuarios, "ID", "NomeUsuario", comentario.UsuarioID);
            return View(comentario);
        }

        // GET: Comentario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comentario comentario = db.Comentarios.Find(id);
            if (comentario == null)
            {
                return HttpNotFound();
            }
            return View(comentario);
        }

        // POST: Comentario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comentario comentario = db.Comentarios.Find(id);
            db.Comentarios.Remove(comentario);
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
