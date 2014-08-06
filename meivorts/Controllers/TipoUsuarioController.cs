using meivorts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace meivorts.Controllers
{
    public class TipoUsuarioController : Controller
    {
        #region objects

        private meivorts_validacaoEntities db = new meivorts_validacaoEntities();

        #endregion

        #region CRUD
        //
        // GET: /TipoUsuario/

        public ActionResult Index()
        {
            var tipoUsuario = db.TipoUsuario.Where(model => model.Excluido == false).ToList();
            return View(tipoUsuario);
        }

        //
        // GET: /TipoUsuario/Create

        public ActionResult Create(int id)
        {
            if (id.Equals(0))
            {
                return View();
            }
            else
            {
                TipoUsuario tipoUsuario = db.TipoUsuario.Find(id);

                return View(tipoUsuario);
            }
        }

        //
        // POST: /TipoUsuario/Create

        [HttpPost]
        public ActionResult Create(int id, TipoUsuario tipoUsuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id.Equals(0))
                    {
                        tipoUsuario.DataAlteracao = tipoUsuario.DataCriacao = DateTime.Now;

                        db.TipoUsuario.Add(tipoUsuario);
                    }
                    else
                    {
                        TipoUsuario tipoUsuarioEdit = new TipoUsuario();

                        tipoUsuarioEdit = db.TipoUsuario.Find(id);

                        tipoUsuarioEdit.DataAlteracao = DateTime.Now;
                        tipoUsuarioEdit.Nome = tipoUsuario.Nome;

                        db.Entry(tipoUsuarioEdit).State = System.Data.Entity.EntityState.Modified;
                    }

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(tipoUsuario);
                }
            }
            catch
            {
                return View(tipoUsuario);
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
                TipoUsuario tipoUsuario = new TipoUsuario();

                //verifica se o tipoContato está sendo usado por algum contato não excluido
                int hasTipoUsuarioInCompromisso = db.Usuario.Where(x => x.TipoUsuario == id && x.Excluido == false).Count();
                if (hasTipoUsuarioInCompromisso.Equals(0))
                {
                    tipoUsuario = db.TipoUsuario.Find(id);

                    tipoUsuario.DataAlteracao = DateTime.Now;
                    tipoUsuario.Excluido = true;

                    db.Entry(tipoUsuario).State = System.Data.Entity.EntityState.Modified;
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
                            Mensagem = "Exclusão não permitida, existem usuários usando este item"
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
