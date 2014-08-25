using meivorts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace meivortsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class MeivortsService : ImeivortsService
    {
        public List<UsuarioService> Usuarios()
        {
            try
            {
                List<UsuarioService> listUsuarioService = new List<UsuarioService>();
                List<Usuario>listUsuarios = new List<Usuario>();

                meivorts_validacaoEntities db = new meivorts_validacaoEntities();

                listUsuarios = db.Usuario.ToList();

                listUsuarios.ForEach(delegate(Usuario _usuarios)
                {
                    UsuarioService usuarioService = new UsuarioService();

                    usuarioService.NomeUsuario = _usuarios.NomeUsuario;
                    usuarioService.Senha = _usuarios.Senha;
                    usuarioService.ID = _usuarios.ID;
                    usuarioService.TipoUsuario = _usuarios.TipoUsuario;
                    usuarioService.Excluido = _usuarios.Excluido;
                    usuarioService.Ativo = _usuarios.Ativo;
                    usuarioService.DataAlteracao = _usuarios.DataAlteracao;
                   // usuarioService.DataCriacao = _usuarios.DataCriacao;
                    usuarioService.DataCriacao = DateTime.Now;

                    listUsuarioService.Add(usuarioService);
                });

                return listUsuarioService;
            }
            catch(Exception ex)
            {
               throw(ex);
            }
        }
    }
}
