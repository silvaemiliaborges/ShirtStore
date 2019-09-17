using Senai.ShirtStore.WebApi.Domains;
using Senai.ShirtStore.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Repositories
{
    public class LoginRepository
    {
        ShirtStoreContext ctx = new ShirtStoreContext();


        public Usuario BuscarEmailESenha(LoginViewModel login)
        {
            Usuario UsuarioBuscado = ctx.Usuario.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
            if (UsuarioBuscado == null)
            {
                return null;
            }
            return UsuarioBuscado;
        }
    }
}
