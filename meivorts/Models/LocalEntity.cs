using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace meivorts.Models
{
    [MetadataType(typeof(LocalEntity))]
    public partial class Local
    {

    }
    public class LocalEntity
    {
        public int ID { get; set; }

        [Required(ErrorMessage="Escreva o nome do local")]
        [Display(Name= "Local")]
        public string NomeLocal { get; set; }

        [Display(Name = "Endereço")]
        public int IDEndereco { get; set; }

        public System.DateTime DataCriacao { get; set; }
        public System.DateTime DataAlteracao { get; set; }
        public bool Excluido { get; set; }

        public virtual ICollection<Compromisso> Compromisso { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}