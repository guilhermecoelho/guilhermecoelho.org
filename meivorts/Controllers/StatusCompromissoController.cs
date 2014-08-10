using meivorts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace meivorts.Controllers
{
    [Authorize]
    public class StatusCompromissoController : Controller
    {
        #region objects

        private meivorts_validacaoEntities db = new meivorts_validacaoEntities();
        
        #endregion

        #region CRUD

        //
        // GET: /StatusCompromisso/

        public ActionResult Index()
        {

            var statusCompromisso = db.StatusCompromisso.Where(x => x.Excluido == false).ToList();

            return View(statusCompromisso);
        }

        //
        // GET: /StatusCompromisso/Create

        public ActionResult Create(int id)
        {
            StatusCompromisso statusCompromisso = new StatusCompromisso();

            if (id.Equals(0))
            {
                statusCompromisso.ID = 0;
            }
            else
            {
                statusCompromisso = db.StatusCompromisso.Find(id);
            }

            return View(statusCompromisso);
        }

        //
        // POST: /StatusCompromisso/Create

        [HttpPost]
        public ActionResult Create(int id, StatusCompromisso statusCompromisso)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (id.Equals(0))
                    {
                        statusCompromisso.DataAlteracao = statusCompromisso.DataCriacao = DateTime.Now;

                        db.StatusCompromisso.Add(statusCompromisso);
                    }
                    else
                    {
                        StatusCompromisso statusCompromissoEdit = new StatusCompromisso();

                        statusCompromissoEdit = db.StatusCompromisso.Find(id);

                        statusCompromissoEdit.DataAlteracao = DateTime.Now;
                        statusCompromissoEdit.Nome = statusCompromisso.Nome;

                        db.Entry(statusCompromissoEdit).State = System.Data.Entity.EntityState.Modified;

                    }
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(statusCompromisso);
                }
            }
            catch
            {
                return View(statusCompromisso);
            }
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            try
            {
                StatusCompromisso statusCompromisso = new StatusCompromisso();

                //verifica se o tipoContato está sendo usado por algum contato não excluido
                int hasStatusInCompromisso = db.Compromisso.Where(x => x.StatusCompromisso == id && x.Excluido == false).Count();
                if (hasStatusInCompromisso.Equals(0))
                {
                    statusCompromisso = db.StatusCompromisso.Find(id);

                    statusCompromisso.DataAlteracao = DateTime.Now;
                    statusCompromisso.Excluido = true;

                    db.Entry(statusCompromisso).State = System.Data.Entity.EntityState.Modified;
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
                            Mensagem = "Exclusão não permitida, existem contatos usando este item"
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

        #endregion
    }
}
