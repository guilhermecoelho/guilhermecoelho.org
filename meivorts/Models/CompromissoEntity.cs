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

        [Required(ErrorMessage="Selecione um local")]
        [Display(Name=" Local ")]
        public int IDLocal { get; set; }

        [Display(Name = " Observação ")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Data")]
        [Display(Name = " Data ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime Data { get; set; }

        [Required(ErrorMessage = "Preencha o campo Hora")]
        [Display(Name = " Hora ")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}")]
        public System.TimeSpan Hora { get; set; }

        [Required(ErrorMessage = "Selecione o tipo de compromisso")]
        [Display(Name = " Tipo de compromisso ")]
        public int TipoCompromisso { get; set; }

        [Required(ErrorMessage = "Selecione um contato")]
        [Display(Name = " Contato ")]
        public int Contato { get; set; }

        [Required(ErrorMessage = "Selecione um status para o Compromisso")]
        [Display(Name = " Status ")]
        public int StatusCompromisso { get; set; }

        public System.DateTime DataCriacao { get; set; }
        public System.DateTime DataAlteracao { get; set; }
        public bool Excluido { get; set; }

        public virtual Contato Contato1 { get; set; }
        public virtual Local Local { get; set; }
        public virtual StatusCompromisso StatusCompromisso1 { get; set; }
        public virtual TipoCompromisso TipoCompromisso1 { get; set; }
    }
}