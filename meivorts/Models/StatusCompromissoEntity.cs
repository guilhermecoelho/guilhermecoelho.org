using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace meivorts.Models
{
    [MetadataType(typeof(StatusCompromissoEntity))]
    public partial class StatusCompromisso
    {

    }
    public class StatusCompromissoEntity
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome ")]
        [Display(Name="Nome")]
        public string Nome { get; set; }

        public System.DateTime DataCriacao { get; set; }
        public System.DateTime DataAlteracao { get; set; }
        public bool Excluido { get; set; }

        public virtual ICollection<Compromisso> Compromisso { get; set; }
    }
}