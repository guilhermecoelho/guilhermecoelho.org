using meivorts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace meivorts.Controllers
{
    public class TipoContatoController : Controller
    {
        private meivortsEntities db = new meivortsEntities();
        //
        // GET: /TipoContato/

        public ActionResult Index()
        {
            var tipoContato = db.TipoContato.ToList();
            return View(tipoContato);

        }

        //
        // GET: /TipoContato/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /TipoContato/Create

        public ActionResult Create(int id)
        {
            TipoContato tipoContato = new TipoContato();

            if (id.Equals(0))
            {
                tipoContato.ID = 0;
            }
            else
            {
                tipoContato = db.TipoContato.Find(id);
            }

            return View(tipoContato);
        }

        //
        // POST: /TipoContato/Create

        [HttpPost]
        public ActionResult Create(int id, TipoContato tipoContato)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (id.Equals(0))
                    {
                        tipoContato.DataAlteracao = tipoContato.DataCriacao = DateTime.Now;

                        db.TipoContato.Add(tipoContato);
                    }
                    else
                    {
                        TipoContato tipoContatoEdit = new TipoContato();

                        tipoContatoEdit = db.TipoContato.Find(id);

                        tipoContatoEdit.DataAlteracao = DateTime.Now;
                        tipoContatoEdit.NomeTipoContato = tipoContato.NomeTipoContato;

                        db.Entry(tipoContatoEdit).State = System.Data.Entity.EntityState.Modified;

                    }
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(tipoContato);
                }
            }
            catch
            {
                return View(tipoContato);
            }
        }

        //
        // GET: /TipoContato/Edit/5

    

        //
        // GET: /TipoContato/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /TipoContato/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, TipoContato tipoContato)
        {
            try
            {
                tipoContato.DataAlteracao = DateTime.Now;
                tipoContato.Excluido = true;

                db.Entry(tipoContato).State = System.Data.Entity.EntityState.Modified;
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
