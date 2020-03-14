using Entity.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLocal.Context
{
    public class dbContext : DbContext
    {
        public dbContext() : base("Facturacion")
        {
            
        }

        public DbSet<ITccproductoscliente> ITccproductoscliente { get; set; }
        public DbSet<TClientes> TClientes { get; set; }
        public DbSet<Tfactura> Tfactura { get; set; }
        public DbSet<TFacturaDetalle> TFacturaDetalle { get; set; }
        public DbSet<TProductos> TProductos { get; set; }
    }
}
