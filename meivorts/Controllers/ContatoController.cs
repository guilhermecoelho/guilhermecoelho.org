using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using meivorts.Controllers;
using meivorts.Models;

namespace meivorts.Controllers
{
    public class ContatoController : Controller
    {
        private meivortsEntities db = new meivortsEntities();

        //
        // GET: /Contato/

        public ActionResult Index()
        {
            var contato = db.Contato.Include("TipoContato1").ToList();
            return View(contato);
        }

        //
        // GET: /Contato/Create

        public ActionResult Create(int id)
        {
            if (id.Equals(0))
            {
                ViewBag.TipoContato = new SelectList(db.TipoContato, "ID", "NomeTipoContato");
                return View();
            }
            else
            {
                Contato contato = db.Contato.Find(id);

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
                    ViewBag.TipoContato = new SelectList(db.TipoContato, "ID", "NomeTipoContato", contato.TipoContato);
                    return View(contato);
                }
            }
            catch
            {
                return View(contato);
            }
        }

        //
        // GET: /Contato/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Contato/Delete/5

        [HttpGet]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateNewMyEntity(string default_value)
        {
            Contato contato = new Contato();
            contato.Facebook = default_value;

            return View(contato);
        }
    }
}
