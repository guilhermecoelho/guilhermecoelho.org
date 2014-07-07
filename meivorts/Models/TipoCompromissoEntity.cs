using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace meivorts.Models
{
    [MetadataType(typeof(TipoCompromissoEntity))]
    public partial class TipoCompromisso
    {
    }
    public class TipoCompromissoEntity
    {
        public int ID { get; set; }

        [Required(ErrorMessage="Preencha o campo nome ")]
        [Display(Name=" Nome ")]
        public string NomeCompromisso { get; set; }
        [Display(Name = " Data criação ")]
        
        public System.DateTime DataCriacao { get; set; }
        [Display(Name = " Data alteração ")]
        public System.DateTime DataAlteracao { get; set; }
        [Display(Name = " Excluido ")]
        public bool Excluido { get; set; }
    }
}