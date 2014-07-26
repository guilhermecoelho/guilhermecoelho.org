using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace meivorts.Models
{
    [MetadataType(typeof(CompromissoEntity))]
    public partial class Compromisso
    {

    }
    public class CompromissoEntity
    {
        public int ID { get; set; }

        [Required(ErrorMessage="Preencha o campo Nome")]
        [Display(Name=" Nome ")]
        public string Nome { get; set; }

        [Display(Name = " Descrição ")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Data")]
        [Display(Name = " Data ")]
        public System.DateTime Data { get; set; }

        [Required(ErrorMessage = "Preencha o campo Hora")]
        [Display(Name = " Hora ")]
        public System.TimeSpan Hora { get; set; }

        [Required(ErrorMessage = "Selecione o tipo de compromisso")]
        [Display(Name = " Tipo de compromisso ")]
        public int TipoCompromisso { get; set; }

        [Required(ErrorMessage = "Selecione um contato")]
        [Display(Name = " Contato ")]
        public int Contato { get; set; }

        [Required(ErrorMessage = "Selecione um status para o Compromisso")]
        [Display(Name = " Nome ")]
        public int StatusCompromisso { get; set; }

        public System.DateTime DataCriacao { get; set; }
        public System.DateTime DataAlteracao { get; set; }
        public bool Excluido { get; set; }

        public virtual Contato Contato1 { get; set; }
        public virtual StatusCompromisso StatusCompromisso1 { get; set; }
        public virtual TipoCompromisso TipoCompromisso1 { get; set; }
    }
}