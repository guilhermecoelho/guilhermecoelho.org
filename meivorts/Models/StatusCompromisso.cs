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
    
    public partial class StatusCompromisso
    {
        public StatusCompromisso()
        {
            this.Compromisso = new HashSet<Compromisso>();
        }
    
        public int ID { get; set; }
        public string Nome { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public System.DateTime DataAlteracao { get; set; }
        public bool Excluido { get; set; }
    
        public virtual ICollection<Compromisso> Compromisso { get; set; }
    }
}
