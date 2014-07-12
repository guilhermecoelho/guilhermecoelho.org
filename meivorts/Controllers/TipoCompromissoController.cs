using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using meivorts.Controllers;
using meivorts.Models;

namespace meivorts.Controllers
{
    public class TipoCompromissoController : Controller
    {

        private meivortsEntities db = new meivortsEntities();

        //
        // GET: /TipoCompromisso/

        public ActionResult Index()
        {
            var tipoCompromisso = db.TipoCompromisso.ToList();
            return View(tipoCompromisso);
        }

        //
        // GET: /TipoCompromisso/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /TipoCompromisso/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TipoCompromisso/Create

        [HttpPost]
        public ActionResult Create(TipoCompromisso tipoCompromisso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tipoCompromisso.DataAlteracao = tipoCompromisso.DataCriacao =  DateTime.Now;

                    db.TipoCompromisso.Add(tipoCompromisso);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(tipoCompromisso);
                }
            }
            catch
            {
                return View(tipoCompromisso);
            }
        }

        //
        // GET: /TipoCompromisso/Edit/5

        public ActionResult Edit(int id)
        {
            TipoCompromisso tipoCompromisso = db.TipoCompromisso.Find(id);

            return View(tipoCompromisso);
        }

        //
        // POST: /TipoCompromisso/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, TipoCompromisso tipoCompromisso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tipoCompromisso.DataAlteracao = DateTime.Now;

                    db.Entry(tipoCompromisso).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(tipoCompromisso);
                }
            }
            catch
            {
                return View(tipoCompromisso);
            }
        }

        //
        // GET: /TipoCompromisso/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /TipoCompromisso/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, TipoCompromisso tipoCompromisso)
        {
            try
            {
                tipoCompromisso.DataAlteracao = DateTime.Now;
                tipoCompromisso.Excluido = true;

                db.Entry(tipoCompromisso).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
