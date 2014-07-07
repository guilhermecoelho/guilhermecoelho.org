using guilhermecoelho.org.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace guilhermecoelho.org.Controllers
{
    public class TipoAgendaController : Controller
    {

        private meivorts_validacaoEntities db = new meivorts_validacaoEntities();

        public ActionResult Index()
        {
            var tipoAgenda = db.tblTipoAgendas.ToList();
            return View(tipoAgenda);
        }

        public ActionResult Edit(Int32 Id)
        {
            var tipoAgenda = db.tblTipoAgendas.Find(Id);

            return View(tipoAgenda);
        }

    }
}
