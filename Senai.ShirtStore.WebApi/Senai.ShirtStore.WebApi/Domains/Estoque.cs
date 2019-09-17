using System;
using System.Collections.Generic;

namespace Senai.ShirtStore.WebApi.Domains
{
    public partial class Estoque
    {
        public Estoque()
        {
            Camiseta = new HashSet<Camiseta>();
        }

        public int IdEstoque { get; set; }
        public string Nome { get; set; }

        public ICollection<Camiseta> Camiseta { get; set; }
    }
}
