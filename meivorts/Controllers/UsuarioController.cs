using meivorts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace meivorts.Controllers
{
    public class UsuarioController : Controller
    {
        #region objects

        private meivorts_validacaoEntities db = new meivorts_validacaoEntities();

        #endregion

        #region CRUD
        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            var usuario = db.Usuario.Where(model => model.Excluido == false).ToList();
            return View(usuario);
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create(int id)
        {
            if (id.Equals(0))
            {
                return View();
            }
            else
            {
                Usuario usuario = db.Usuario.Find(id);

                return View(usuario);
            }
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        public ActionResult Create(int id, Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id.Equals(0))
                    {
                        usuario.DataAlteracao = usuario.DataCriacao = DateTime.Now;
                        usuario.Senha = Util.PasswordHash.CreateHash(usuario.Senha);
                        usuario.Ativo = true;

                        db.Usuario.Add(usuario);
                    }
                    else
                    {
                        Usuario usuarioEdit = new Usuario();

                        usuarioEdit = db.Usuario.Find(id);

                        usuarioEdit.DataAlteracao = DateTime.Now;
                        usuarioEdit.NomeUsuario = usuario.NomeUsuario;
                        usuarioEdit.TipoUsuario = 1;
                        usuarioEdit.Senha = Util.PasswordHash.CreateHash(usuario.Senha);
                        usuarioEdit.Ativo = usuario.Ativo;

                        db.Entry(usuarioEdit).State = System.Data.Entity.EntityState.Modified;
                    }

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(usuario);
                }
            }
            catch
            {
                return View(usuario);
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
                Usuario usuario = new Usuario();

                usuario = db.Usuario.Find(id);

                usuario.DataAlteracao = DateTime.Now;
                usuario.Excluido = true;

                db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
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
  
    }
}
