using meivorts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace meivorts.Controllers
{
    public class LocalController : Controller
    {
        #region objects

        private meivortsEntities db = new meivortsEntities();

        #endregion

        #region CRUD

        //
        // GET: /Local/

        public ActionResult Index()
        {
            var local = db.Local.Include("Endereco").Where(x => x.Excluido == false).ToList();
            return View(local);
        }

        //
        // GET: /Local/Create

        public ActionResult Create(int id)
        {
            Local local = new Local();

            if (id.Equals(0))
            {
                populaDropDowns(local);

                return View();
            }
            else
            {
                local = db.Local.Find(id);
                populaDropDowns(local);

                return View(local);
            }
        }

        //
        // POST: /Local/Create

        [HttpPost]
        public ActionResult Create(Local local, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id.Equals(0))
                    {
                        local.DataAlteracao = local.DataCriacao = DateTime.Now;

                        db.Local.Add(local);
                    }
                    else
                    {
                        Local localEdit = new Local();

                        localEdit = db.Local.Find(id);

                        localEdit.DataAlteracao = DateTime.Now;
                        localEdit.NomeLocal = local.NomeLocal;
                        localEdit.IDEndereco = local.IDEndereco;

                        db.Entry(localEdit).State = System.Data.Entity.EntityState.Modified;
                    }

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    populaDropDowns(local);

                    return View(local);
                }
            }
            catch
            {
                populaDropDowns(local);

                return View(local);
            }
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            try
            {
                Local local = new Local();

                local = db.Local.Find(id);

                local.DataAlteracao = DateTime.Now;
                local.Excluido = true;

                db.Entry(local).State = System.Data.Entity.EntityState.Modified;
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
        /// <param name="compromisso">Local object</param>
        private void populaDropDowns(Local local)
        {
            ViewBag.TipoLocal = new SelectList(db.Endereco.Where(x => x.Excluido == false), "ID", "ID", local.Endereco);
        }

        #endregion

    }
}
