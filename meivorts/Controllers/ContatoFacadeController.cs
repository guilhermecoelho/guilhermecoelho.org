﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using meivorts.Controllers;
using meivorts.Models;
using System.Security.Cryptography;
using System.Text;
using PagedList;

namespace meivorts.Controllers
{
    [Authorize]
    public class ContatoFacadeController : Controller
    {
        #region objects

        private meivorts_validacaoEntities db = new meivorts_validacaoEntities();

        #endregion

        #region CRUD

        //
        // GET: /Contato/


        public ActionResult Index()
        {
            //realiza a busca
           // var contato = db.Contato.Include("TipoContato1").Where(x => x.Excluido == false).ToList();
            return View(RedirectToAction("Contato"));
        }

        //
        // GET: /Contato/Create

        public ActionResult Create(int id)
        {
            Contato contato = new Contato();

            if (id.Equals(0))
            {
                populaDropDowns(contato);

                return View();
            }
            else
            {
                contato = db.Contato.Find(id);
                populaDropDowns(contato);

                return View(contato);
            }
        }

        //
        // POST: /Contato/Create

        [HttpPost]
        public ActionResult Create(Contato contato, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id.Equals(0))
                    {
                        contato.DataAlteracao = contato.DataCriacao = DateTime.Now;

                        db.Contato.Add(contato);
                    }
                    else
                    {
                        Contato contatoEdit = new Contato();

                        contatoEdit = db.Contato.Find(id);

                        contatoEdit.DataAlteracao = DateTime.Now;
                        contatoEdit.Email = contato.Email;
                        contatoEdit.Facebook = contato.Facebook;
                        contatoEdit.Nome = contato.Nome;
                        contatoEdit.Observacao = contato.Observacao;
                        contatoEdit.Telefone = contato.Telefone;
                        contatoEdit.TipoContato = contato.TipoContato;
                        contatoEdit.Twitter = contato.Twitter;

                        db.Entry(contatoEdit).State = System.Data.Entity.EntityState.Modified;
                    }

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    populaDropDowns(contato);

                    return View(contato);
                }
            }
            catch
            {
                populaDropDowns(contato);

                return View(contato);
            }
        }

        [HttpGet]
        public JsonResult Delete(int id)
        {
            try
            {
                Contato contato = new Contato();

                contato = db.Contato.Find(id);

                contato.DataAlteracao = DateTime.Now;
                contato.Excluido = true;

                db.Entry(contato).State = System.Data.Entity.EntityState.Modified;
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
        /// <param name="compromisso">Contato object</param>
        private void populaDropDowns(Contato contato)
        {
            ViewBag.TipoContato = new SelectList(db.TipoContato.Where(x => x.Excluido == false), "ID", "NomeTipoContato", contato.TipoContato);
        }

        #endregion
    }
}
