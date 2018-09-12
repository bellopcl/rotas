using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoRotas.Models
{
    public class EnderecoQuantidade
    {
        public string CLIENTE { get; set; }
        public string ENDERECO { get; set; }
        public string BAIRRO { get; set; }
        public string CIDADE { get; set; }
        public string ESTADO { get; set; }
        public decimal CUBAGEM { get; set; }
        public decimal PESO_BRUTO { get; set; }
        public decimal VALOR_BRUTO { get; set; }
        public string ENDERECOCOMPLETO { get; set; }
    }
}