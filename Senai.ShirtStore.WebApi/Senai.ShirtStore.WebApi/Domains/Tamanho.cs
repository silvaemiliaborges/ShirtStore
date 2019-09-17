using System;
using System.Collections.Generic;

namespace Senai.ShirtStore.WebApi.Domains
{
    public partial class Tamanho
    {
        public Tamanho()
        {
            Camiseta = new HashSet<Camiseta>();
        }

        public int IdTamanho { get; set; }
        public string Nome { get; set; }

        public ICollection<Camiseta> Camiseta { get; set; }
    }
}
