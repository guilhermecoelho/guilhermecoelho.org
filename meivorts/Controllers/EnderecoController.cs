using meivorts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace meivorts.Controllers
{
    public class EnderecoController : Controller
    {
        #region objects

        private meivorts_validacaoEntities db = new meivorts_validacaoEntities();

        #endregion

        #region CRUD

        //
        // GET: /TipoContato/

        public ActionResult Index()
        {
            var endereco = db.Endereco.Where(x => x.Excluido == false).ToList();
            return View(endereco);
        }

        // GET: /TipoContato/Create

        public ActionResult Create(int id)
        {
            Endereco endereco = new Endereco();

            if (id.Equals(0))
            {
                endereco.ID = 0;
            }
            else
            {
                endereco = db.Endereco.Find(id);
            }

            return View(endereco);
        }

        //
        // POST: /TipoContato/Create

        [HttpPost]
        public ActionResult Create(int id, Endereco endereco)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (id.Equals(0))
                    {
                        endereco.DataAlteracao = endereco.DataCriacao = DateTime.Now;

                        db.Endereco.Add(endereco);
                    }
                    else
                    {
                        Endereco enderecoEdit = new Endereco();

                        enderecoEdit = db.Endereco.Find(id);

                        enderecoEdit.DataAlteracao = DateTime.Now;
                        enderecoEdit.Bairro = endereco.Bairro;
                        enderecoEdit.CEP = endereco.CEP;
                        enderecoEdit.Cidade = endereco.Cidade;
                        enderecoEdit.Complemento = endereco.Complemento;
                        enderecoEdit.Local = endereco.Local;
                        enderecoEdit.Numero = endereco.Numero;
                        enderecoEdit.Rua = endereco.Rua;
                        enderecoEdit.UF = endereco.UF;

                        db.Entry(enderecoEdit).State = System.Data.Entity.EntityState.Modified;

                    }
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(endereco);
                }
            }
            catch
            {
                return View(endereco);
            }
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            try
            {
                Endereco endereco = new Endereco();

                //verifica se o tipoContato está sendo usado por algum contato não excluido
                int hasLocalInEndereco = db.Local.Where(x => x.IDEndereco == id && x.Excluido == false).Count();
                if (hasLocalInEndereco.Equals(0))
                {
                    endereco = db.Endereco.Find(id);

                    endereco.DataAlteracao = DateTime.Now;
                    endereco.Excluido = true;

                    db.Entry(endereco).State = System.Data.Entity.EntityState.Modified;
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
                            Mensagem = "Exclusão não permitida, existem Locais usando este item"
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
