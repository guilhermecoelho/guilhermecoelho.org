using meivorts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace meivorts.Controllers
{
    [Authorize]
    public class TipoContatoController : Controller
    {
        #region objects

        private meivorts_validacaoEntities db = new meivorts_validacaoEntities();

        #endregion

        #region CRUD

        //
        // GET: /TipoContato/

        public ActionResult Index()
        {
            var tipoContato = db.TipoContato.Where(x => x.Excluido == false).ToList();
            return View(tipoContato);
        }

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

        [HttpGet]
        public JsonResult Delete(int id)
        {
            try
            {
                TipoContato tipoContato = new TipoContato();

                //verifica se o tipoContato está sendo usado por algum contato não excluido
                int hasTipoContatoInContato = db.Contato.Where(x => x.TipoContato == id && x.Excluido == false).Count();
                if (hasTipoContatoInContato.Equals(0))
                {
                    tipoContato = db.TipoContato.Find(id);

                    tipoContato.DataAlteracao = DateTime.Now;
                    tipoContato.Excluido = true;

                    db.Entry(tipoContato).State = System.Data.Entity.EntityState.Modified;
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
