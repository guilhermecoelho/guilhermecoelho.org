using meivorts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace meivorts.Controllers
{
    public class LoginController : Controller
    {
        #region objects

        private meivorts_validacaoEntities db = new meivorts_validacaoEntities();

        #endregion

        #region CRUD
        [HttpGet]
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(FormCollection f, string returnUrl)
        {
            Usuario usuario = new Usuario();

            var nomeUsuario = f["nomeUsuario"];
            var senha = f["Senha"];

            usuario = db.Usuario.Where(x => x.NomeUsuario == nomeUsuario).FirstOrDefault();

            if (usuario != null)
            {
                //valida a senha digitada com a senha criptografada no banco
                bool senhaCorreta = Util.PasswordHash.ValidatePassword(senha, usuario.Senha);

                if (senhaCorreta)
                {
                    f["Senha"] = usuario.Senha;

                    FormsAuthentication.SetAuthCookie(f["login"], false);
                    return Redirect(returnUrl);
                }
            }
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return Redirect("~/Compromisso/Index");
        }

    }
        #endregion

        
}
