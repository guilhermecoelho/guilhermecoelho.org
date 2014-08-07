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

        [Display(Name="Nome")]
        [Required(ErrorMessage="Preencha um nome")]
        public string NomeUsuario { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Preencha uma senha")]
        public string Senha { get; set; }

        public int TipoUsuario { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public System.DateTime DataAlteracao { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }

        public virtual TipoUsuario TipoUsuario1 { get; set; }
    }

}