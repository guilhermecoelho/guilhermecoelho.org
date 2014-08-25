using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace meivortsService
{
    [ServiceContract]
    public interface ImeivortsService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "usuarios/")]
        [Description("Lista todos usuários")]
        List<UsuarioService> Usuarios();
    }

    [DataContract]
    public class UsuarioService
    {

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string NomeUsuario { get; set; }

        [DataMember]
        public string Senha { get; set; }

        [DataMember]
        public int TipoUsuario { get; set; }

        [DataMember]
        public DateTime DataCriacao { get; set; }

        [DataMember]
        public DateTime DataAlteracao { get; set; }

        [DataMember]
        public bool Ativo { get; set; }

        [DataMember]
        public bool Excluido { get; set; }
    }
}
