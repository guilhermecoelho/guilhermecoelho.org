//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace meivorts.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuario
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
