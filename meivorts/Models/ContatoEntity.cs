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
        public string Nome { get; set; }
        public string Observacao { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public int TipoContato { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public System.DateTime DataAlteracao { get; set; }
        public bool Excluido { get; set; }
    
        public virtual ICollection<Compromisso> Compromissoes { get; set; }
        public virtual TipoContato TipoContato1 { get; set; }
    
    }
}