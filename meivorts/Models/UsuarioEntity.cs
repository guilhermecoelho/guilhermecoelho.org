using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace meivorts.Models
{
    [MetadataType(typeof(UsuarioEntity))]
    public partial class Usuario
    {

    }
    public class UsuarioEntity
    {

        public int ID { get; set; }

        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string ComplementoSenha { get; set; }
        public int TipoUsuario { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public System.DateTime DataAlteracao { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }

        public virtual TipoUsuario TipoUsuario1 { get; set; }
    }

}