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

        private meivorts_validacaoEntities db = new meivorts_validacaoEntities();

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
                return View();
            }
            else
            {
                local = db.Local.Find(id);

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
                        local.Endereco.DataAlteracao = local.Endereco.DataCriacao = DateTime.Now;

                        db.Endereco.Add(local.Endereco);
                        db.Local.Add(local);

                    }
                    else
                    {
                        Local localEdit = new Local();

                        localEdit = db.Local.Find(id);

                        localEdit.DataAlteracao = DateTime.Now;
                        localEdit.NomeLocal = local.NomeLocal;

                        localEdit.Endereco.Bairro = local.Endereco.Bairro;
                        localEdit.Endereco.CEP = local.Endereco.CEP;
                        localEdit.Endereco.Cidade = local.Endereco.Cidade;
                        localEdit.Endereco.Complemento = local.Endereco.Complemento;
                        localEdit.Endereco.Numero = local.Endereco.Numero;
                        localEdit.Endereco.Rua = local.Endereco.Rua;
                        localEdit.Endereco.UF = local.Endereco.UF;
                        localEdit.Endereco.DataAlteracao = DateTime.Now;

                        db.Entry(localEdit).State = System.Data.Entity.EntityState.Modified;

                    }

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {

                    return View(local);
                }
            }
            catch
            {

                return View(local);
            }
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            try
            {
                Local local = new Local();

                int hasLocalInCompromisso = db.Compromisso.Where(x => x.IDLocal == id && x.Excluido == false).Count();
                if (hasLocalInCompromisso.Equals(0))
                {
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
                else
                {
                    return Json(
                        new
                        {
                            OK = false,
                            Mensagem = "Exclusão não permitida, existem Compromissos usando este item"
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

        #region methods

        #endregion

    }
}
