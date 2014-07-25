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
            var tipoCompromisso = db.TipoCompromisso.Where(model => model.Excluido == false).ToList();
            return View(tipoCompromisso);
        }

        //
        // GET: /TipoCompromisso/Create

        public ActionResult Create(int id)
        {
            if (id.Equals(0))
            {
                return View();
            }
            else
            {
                TipoCompromisso tipoCompromisso = db.TipoCompromisso.Find(id);

                return View(tipoCompromisso);
            }
        }

        //
        // POST: /TipoCompromisso/Create

        [HttpPost]
        public ActionResult Create(int id, TipoCompromisso tipoCompromisso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id.Equals(0))
                    {
                        tipoCompromisso.DataAlteracao = tipoCompromisso.DataCriacao = DateTime.Now;

                        db.TipoCompromisso.Add(tipoCompromisso);
                    }
                    else
                    {
                        TipoCompromisso tipoCompromissoEdit = new TipoCompromisso();

                        tipoCompromissoEdit = db.TipoCompromisso.Find(id);

                        tipoCompromissoEdit.DataAlteracao = DateTime.Now;
                        tipoCompromissoEdit.NomeCompromisso = tipoCompromisso.NomeCompromisso;

                        db.Entry(tipoCompromissoEdit).State = System.Data.Entity.EntityState.Modified;
                    }

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Delete(int id)
        {
            try
            {
                TipoCompromisso tipoCompromisso = new TipoCompromisso();

                //verifica se o tipoContato está sendo usado por algum contato não excluido
                int hasTipoCompromissoInCompromisso = db.Compromisso.Where(x => x.TipoCompromisso == id && x.Excluido == false).Count();
                if (hasTipoCompromissoInCompromisso.Equals(0))
                {
                    tipoCompromisso = db.TipoCompromisso.Find(id);

                    tipoCompromisso.DataAlteracao = DateTime.Now;
                    tipoCompromisso.Excluido = true;

                    db.Entry(tipoCompromisso).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return Json(
                        new
                        {
                            OK = true,
                            Mensagem = "Item excluido com sucesso"
                        },
                        JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(
                        new
                        {
                            OK = false,
                            Mensagem = "Exclusão não permitida, existem compromissos usando este item"
                        },
                        JsonRequestBehavior.AllowGet);
                }
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
    }
}
