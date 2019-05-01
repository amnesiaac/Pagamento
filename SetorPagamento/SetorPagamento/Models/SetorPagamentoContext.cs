using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SetorPagamento.Models
{
    public class SetorPagamentoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SetorPagamentoContext() : base("name=SetorPagamentoContext")
        {
        }

        public System.Data.Entity.DbSet<SetorPagamento.Models.Pedido> Pedidoes { get; set; }

        public System.Data.Entity.DbSet<SetorPagamento.Models.Pagamento> Pagamentoes { get; set; }

        public System.Data.Entity.DbSet<SetorPagamento.Models.PagamentoCartaoCredito> PagamentoCartaoCreditoes { get; set; }

        public System.Data.Entity.DbSet<SetorPagamento.Models.PagamentoCartaoDebito> PagamentoCartaoDebitoes { get; set; }

        public System.Data.Entity.DbSet<SetorPagamento.Models.PagamentoDinheiro> PagamentoDinheiroes { get; set; }
    }
}
