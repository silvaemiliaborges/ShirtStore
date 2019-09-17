using System;
using System.Collections.Generic;

namespace Senai.ShirtStore.WebApi.Domains
{
    public partial class Marca
    {
        public Marca()
        {
            Camiseta = new HashSet<Camiseta>();
        }

        public int IdMarca { get; set; }
        public string Nome { get; set; }

        public ICollection<Camiseta> Camiseta { get; set; }
    }
}
