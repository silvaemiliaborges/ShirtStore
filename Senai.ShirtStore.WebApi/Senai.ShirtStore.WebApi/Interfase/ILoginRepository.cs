using Senai.ShirtStore.WebApi.Domains;
using Senai.ShirtStore.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.ShirtStore.WebApi.Interfase
{
    interface ILoginRepository
    {
        Usuario BuscarEmailESenha(LoginViewModel login);
    }
}
