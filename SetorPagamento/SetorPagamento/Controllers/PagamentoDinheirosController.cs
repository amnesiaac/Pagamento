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
    public class PagamentoDinheirosController : Controller
    {
        private SetorPagamentoContext db = new SetorPagamentoContext();

        // GET: PagamentoDinheiros
        public ActionResult Index()
        {
            var pagamentoDinheiroes = db.PagamentoDinheiroes.Include(p => p.Pagamento);
            return View(pagamentoDinheiroes.ToList());
        }

        // GET: PagamentoDinheiros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagamentoDinheiro pagamentoDinheiro = db.PagamentoDinheiroes.Find(id);
            if (pagamentoDinheiro == null)
            {
                return HttpNotFound();
            }
            return View(pagamentoDinheiro);
        }

        // GET: PagamentoDinheiros/Create
        public ActionResult Create(int ? id)
        {
            ViewBag.PagamentoId = db.Pagamentoes.Find(id);
            return View();
        }

        // POST: PagamentoDinheiros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PagamentoDinheiroId,Valor,PagamentoId")] PagamentoDinheiro pagamentoDinheiro)
        {
            if (ModelState.IsValid)
            {
                
                Pagamento pagamento = new Pagamento();
                Pedido pedido = new Pedido();
                pedido.PedidoId = pagamento.PedidoId;
                if (pedido.ValorTotal != 0)
                {
                    pedido.ValorTotal -= pagamentoDinheiro.Valor;
                    db.Entry(pedido).State = EntityState.Modified;
                    db.SaveChanges();
                }
                if(pedido.ValorTotal != 0)
                {
                    return RedirectToAction("Create");
                }
                //pagamentoDinheiro.PagamentoDinheiroId = pagamento.PagamentoId;
                //db.PagamentoDinheiroes.Add(pagamentoDinheiro);
                
               // pedido.ValorCliente -= pagamentoRelacionado.Dinheiro.Valor;
                //pedido.ValorCliente -= pagamentoRelacionado.CartaoCredito.Valor;
                //pedido.ValorCliente -= pagamentoRelacionado.CartaoDebito.Valor;
                //db.Entry(pedido).State = EntityState.Modified;
                //db.SaveChanges();

//                if (pedido.ValorCliente != 0)
  //              {
    //                return RedirectToAction("Create");
      //          }
             
                return RedirectToAction("Index");
            }

            ViewBag.PagamentoId = new SelectList(db.Pagamentoes, "PagamentoId", "PagamentoId", pagamentoDinheiro.PagamentoId);
            return View(pagamentoDinheiro);
        }

        // GET: PagamentoDinheiros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagamentoDinheiro pagamentoDinheiro = db.PagamentoDinheiroes.Find(id);
            if (pagamentoDinheiro == null)
            {
                return HttpNotFound();
            }
            ViewBag.PagamentoId = new SelectList(db.Pagamentoes, "PagamentoId", "PagamentoId", pagamentoDinheiro.PagamentoId);
            return View(pagamentoDinheiro);
        }

        // POST: PagamentoDinheiros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PagamentoDinheiroId,Valor,PagamentoId")] PagamentoDinheiro pagamentoDinheiro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagamentoDinheiro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PagamentoId = new SelectList(db.Pagamentoes, "PagamentoId", "PagamentoId", pagamentoDinheiro.PagamentoId);
            return View(pagamentoDinheiro);
        }

        // GET: PagamentoDinheiros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PagamentoDinheiro pagamentoDinheiro = db.PagamentoDinheiroes.Find(id);
            if (pagamentoDinheiro == null)
            {
                return HttpNotFound();
            }
            return View(pagamentoDinheiro);
        }

        // POST: PagamentoDinheiros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PagamentoDinheiro pagamentoDinheiro = db.PagamentoDinheiroes.Find(id);
            db.PagamentoDinheiroes.Remove(pagamentoDinheiro);
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
