using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace meivorts.Models
{
    [MetadataType(typeof(ContatoEntity))]
    public partial class Contato
    {

    }

    public class ContatoEntity
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome ")]
        [Display(Name = " Nome ")]
        public string Nome { get; set; }

        [Display(Name = " Observação ")]
        public string Observacao { get; set; }

        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }

        
        [Display(Name = " Tipo de contato ")]
        [Required(ErrorMessage = "Selecione um tipo de contato")]
        public int TipoContato { get; set; }

        [Display(Name = " Data Criação ")]
        public System.DateTime DataCriacao { get; set; }

        [Display(Name = " Data Alteração ")]
        public System.DateTime DataAlteracao { get; set; }

        public bool Excluido { get; set; }
    
        public virtual ICollection<Compromisso> Compromisso { get; set; }
        public virtual TipoContato TipoContato1 { get; set; }
    
    }
}