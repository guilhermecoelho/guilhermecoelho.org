﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace meivorts.Models
{
    [MetadataType(typeof(TipoContatoEntity))]
    public partial class TipoContato
    {

    }
    public class TipoContatoEntity
    {
        public int ID { get; set; }
        public string NomeTipoContato { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public System.DateTime DataAlteracao { get; set; }
        public bool Excluido { get; set; }

        public virtual ICollection<Contato> Contatoes { get; set; }
    }
}