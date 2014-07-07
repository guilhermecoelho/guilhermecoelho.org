using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace guilhermecoelho.org.Models
{
    [MetadataType(typeof(TipoAgendaEntity))]
    public partial class tblTipoAgenda
    {
    }
    public class TipoAgendaEntity
    {
        public string Nome { get; set; }
        public System.DateTime DataGravacao { get; set; }
        public System.DateTime DataAlteracao { get; set; }
        public bool Excluido { get; set; }
    }
}