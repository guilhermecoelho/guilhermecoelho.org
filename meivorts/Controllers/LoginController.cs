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

        [HttpGet]
        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(FormCollection f, string returnUrl)
        {
            var usuario = f["usuario"];
            var senha = f["senha"];

            ///
            /// criar verificação do usuário 
            ///

            if (usuario == "guilherme" && senha == "123")
            {
                FormsAuthentication.SetAuthCookie(f["login"], false);

                return Redirect(returnUrl);
            }
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return Redirect("~/Compromisso/Index");
        }

    }
}
