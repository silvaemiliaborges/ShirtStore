using System;
using System.Collections.Generic;

namespace Senai.ShirtStore.WebApi.Domains
{
    public partial class Camiseta
    {
        public int IdCamiseta { get; set; }
        public string Descricao { get; set; }
        public int? IdCor { get; set; }
        public int? IdTamanho { get; set; }
        public int? IdMarca { get; set; }
        public int? IdEstoque { get; set; }

        public Cor IdCorNavigation { get; set; }
        public Estoque IdEstoqueNavigation { get; set; }
        public Marca IdMarcaNavigation { get; set; }
        public Tamanho IdTamanhoNavigation { get; set; }
    }
}
