using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetorPagamento.Models
{
    public class PagamentoCartaoDebito
    {
        public int PagamentoCartaoDebitoId { get; set; }
        public float Valor { get; set; }

        public int PagamentoId { get; set; }
        public virtual  Pagamento Pagamento { get; set; }
    }
}