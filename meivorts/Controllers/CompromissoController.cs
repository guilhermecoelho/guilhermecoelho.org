using meivorts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace meivorts.Controllers
{
    public class CompromissoController : Controller
    {
        #region objects

        private meivortsEntities db = new meivortsEntities();

        #endregion

        #region CRUD
        //
        // GET: /Compromisso/

        public ActionResult Index()
        {
            var compromisso = db.Compromisso.Include("Contato1").Include("StatusCompromisso1").Include("TipoCompromisso1").Include("Local").Where(x => x.Excluido == false).ToList().OrderBy(x => x.TipoCompromisso1.NomeCompromisso);
            return View(compromisso);
        }
        //
        // GET: /Compromisso/Create

        public ActionResult Create(int id)
        {
            Compromisso compromisso = new Compromisso();

            if (id.Equals(0))
            {
                populaDropDowns(compromisso);

                return View();
            }
            else
            {
                compromisso = db.Compromisso.Find(id);

                populaDropDowns(compromisso);

                return View(compromisso);
            }
        }

        //
        // POST: /Compromisso/Create

        [HttpPost]
        public ActionResult Create(Compromisso compromisso, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id.Equals(0))
                    {
                        compromisso.DataAlteracao = compromisso.DataCriacao = DateTime.Now;

                        db.Compromisso.Add(compromisso);
                    }
                    else
                    {
                        Compromisso compromissoEdit = new Compromisso();

                        compromissoEdit = db.Compromisso.Find(id);

                        compromissoEdit.DataAlteracao = DateTime.Now;
                        compromissoEdit.Descricao = compromisso.Descricao;
                        compromissoEdit.Data = compromisso.Data;
                        compromissoEdit.Hora = compromisso.Hora;
                        compromissoEdit.TipoCompromisso = compromisso.TipoCompromisso;
                        compromissoEdit.Contato = compromisso.Contato;
                        compromissoEdit.StatusCompromisso = compromisso.StatusCompromisso;
                        compromissoEdit.IDLocal = compromisso.IDLocal;

                        db.Entry(compromissoEdit).State = System.Data.Entity.EntityState.Modified;
                    }

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    populaDropDowns(compromisso);

                    return View(compromisso);
                }
            }
            catch
            {
                populaDropDowns(compromisso);

                return View(compromisso);
            }
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            try
            {
                Compromisso compromisso = new Compromisso();

                compromisso = db.Compromisso.Find(id);

                compromisso.DataAlteracao = DateTime.Now;
                compromisso.Excluido = true;

                db.Entry(compromisso).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return Json(
                    new
                    {
                        OK = true,
                        Mensagem = "Item excluido com sucesso"
                    },
                    JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(
                   new
                   {
                       OK = false,
                       Mensagem = "erro ao tentar excluir item"
                   },
                   JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region methods

        /// <summary>
        /// Populate dropdowns 
        /// </summary>
        /// <param name="compromisso">Compromisso object</param>
        private void populaDropDowns(Compromisso compromisso)
        {
            ViewBag.Contato = new SelectList(db.Contato.Where(x => x.Excluido == false), "ID", "Nome", compromisso.Contato);
            ViewBag.StatusCompromisso = new SelectList(db.StatusCompromisso.Where(x => x.Excluido == false), "ID", "Nome", compromisso.StatusCompromisso);
            ViewBag.TipoCompromisso = new SelectList(db.TipoCompromisso.Where(x => x.Excluido == false), "ID", "NomeCompromisso", compromisso.TipoCompromisso);
            ViewBag.IDLocal = new SelectList(db.Local.Where(x => x.Excluido == false), "ID", "NomeLocal", compromisso.IDLocal);
        }

        #endregion

    }
}
