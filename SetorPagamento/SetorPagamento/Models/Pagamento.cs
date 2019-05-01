using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SetorPagamento.Models
{
    public class Pagamento
    {
        public int PagamentoId { get; set; }
        public float ValorCliente { get; set; }

        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}