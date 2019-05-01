using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SetorPagamento.Models;

namespace SetorPagamento.Controllers
{
    public class PagamentoCartaoCreditosController : Controller
    {
        private SetorPagamentoContext db = new SetorPagamentoContext();

        // GET: PagamentoCartaoCreditos
        public ActionResult Index()
        {
            var pagamentoCartaoCreditoes = db.PagamentoCartaoCreditoes.Include(p => p.Pagamento);
            return View(pagamentoCartaoCreditoes.ToList());
        }

        // GET: PagamentoCartaoCreditos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagamentoCartaoCredito pagamentoCartaoCredito = db.PagamentoCartaoCreditoes.Find(id);
            if (pagamentoCartaoCredito == null)
            {
                return HttpNotFound();
            }
            return View(pagamentoCartaoCredito);
        }

        // GET: PagamentoCartaoCreditos/Create
        public ActionResult Create()
        {
            ViewBag.PagamentoId = new SelectList(db.Pagamentoes, "PagamentoId", "PagamentoId");
            return View();
        }

        // POST: PagamentoCartaoCreditos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PagamentoCartaoCreditoId,Valor,PagamentoId")] PagamentoCartaoCredito pagamentoCartaoCredito)
        {
            if (ModelState.IsValid)
            {
                db.PagamentoCartaoCreditoes.Add(pagamentoCartaoCredito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PagamentoId = new SelectList(db.Pagamentoes, "PagamentoId", "PagamentoId", pagamentoCartaoCredito.PagamentoId);
            return View(pagamentoCartaoCredito);
        }

        // GET: PagamentoCartaoCreditos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagamentoCartaoCredito pagamentoCartaoCredito = db.PagamentoCartaoCreditoes.Find(id);
            if (pagamentoCartaoCredito == null)
            {
                return HttpNotFound();
            }
            ViewBag.PagamentoId = new SelectList(db.Pagamentoes, "PagamentoId", "PagamentoId", pagamentoCartaoCredito.PagamentoId);
            return View(pagamentoCartaoCredito);
        }

        // POST: PagamentoCartaoCreditos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PagamentoCartaoCreditoId,Valor,PagamentoId")] PagamentoCartaoCredito pagamentoCartaoCredito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagamentoCartaoCredito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PagamentoId = new SelectList(db.Pagamentoes, "PagamentoId", "PagamentoId", pagamentoCartaoCredito.PagamentoId);
            return View(pagamentoCartaoCredito);
        }

        // GET: PagamentoCartaoCreditos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagamentoCartaoCredito pagamentoCartaoCredito = db.PagamentoCartaoCreditoes.Find(id);
            if (pagamentoCartaoCredito == null)
            {
                return HttpNotFound();
            }
            return View(pagamentoCartaoCredito);
        }

        // POST: PagamentoCartaoCreditos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PagamentoCartaoCredito pagamentoCartaoCredito = db.PagamentoCartaoCreditoes.Find(id);
            db.PagamentoCartaoCreditoes.Remove(pagamentoCartaoCredito);
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
