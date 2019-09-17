using System;
using System.Collections.Generic;

namespace Senai.ShirtStore.WebApi.Domains
{
    public partial class Cor
    {
        public Cor()
        {
            Camiseta = new HashSet<Camiseta>();
        }

        public int IdCor { get; set; }
        public string Nome { get; set; }

        public ICollection<Camiseta> Camiseta { get; set; }
    }
}
