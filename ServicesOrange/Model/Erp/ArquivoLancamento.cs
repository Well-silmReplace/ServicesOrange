using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicesOrange.Model.Erp
{
    public class ArquivoLancamento
    {
        public int IdOperacaoOrange { get; set; }
        public string Competência { get; set; }
        public string CnpjVendedor { get; set; }
        public string CNPJcomprador { get; set; }
        public int CodigoERPComprador { get; set; }
        public int CodigoERPVendedor { get; set; }
        public decimal Quantidade { get; set; }
        public decimal PU { get; set; }
        public decimal ValorTotalSemImposto { get; set; }
    }
}
