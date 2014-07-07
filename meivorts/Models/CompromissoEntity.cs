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
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public System.DateTime Data { get; set; }
        public System.TimeSpan Hora { get; set; }
        public int TipoCompromisso { get; set; }
        public int Contato { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public System.DateTime DataAlteracao { get; set; }
        public bool Excluido { get; set; }
        public bool Ativo { get; set; }
    }
}