using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace meivorts.Models
{
    [MetadataType(typeof(TipoUsuarioEntity))]
    public partial class TipoUsuario
    {

    }

    public class TipoUsuarioEntity
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public System.DateTime DataAlteracao { get; set; }
        public bool Excluido { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}