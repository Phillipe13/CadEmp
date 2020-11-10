using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CadEmp.Models;

namespace CadEmp.Controllers
{
    public class CadastroController : Controller
    {
        private Context db = new Context();

        // GET: Cadastro
        public ActionResult Index()
        {
            return View(db.Cadastros.ToList());
        }

        // GET: Cadastro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadastro cadastro = db.Cadastros.Find(id);
            if (cadastro == null)
            {
                return HttpNotFound();
            }
            return View(cadastro);
        }

        // GET: Cadastro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cadastro/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cnpj,nome_fantasia,telefone,email")] Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                db.Cadastros.Add(cadastro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastro);
        }

        // GET: Cadastro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadastro cadastro = db.Cadastros.Find(id);
            if (cadastro == null)
            {
                return HttpNotFound();
            }
            return View(cadastro);
        }

        // POST: Cadastro/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cnpj,nome_fantasia,telefone,email")] Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastro);
        }

        // GET: Cadastro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cadastro cadastro = db.Cadastros.Find(id);
            if (cadastro == null)
            {
                return HttpNotFound();
            }
            return View(cadastro);
        }

        // POST: Cadastro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cadastro cadastro = db.Cadastros.Find(id);
            db.Cadastros.Remove(cadastro);
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
