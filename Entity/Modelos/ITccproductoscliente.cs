using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Modelos
{
    [Table("CCPRODUCTOSCLIENTE")]
    public class ITccproductoscliente
    {
        [Key]
        public int codigo { get; set; }
        public int codigoCliente { get; set; }
        [ForeignKey("codigoCliente")]
        public virtual TClientes TClientes { get; set; }
        public int codigoProductos { get; set; }
        [ForeignKey("codigoProductos")]
        public virtual TProductos TProductos { get; set;}
        public int precio { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
