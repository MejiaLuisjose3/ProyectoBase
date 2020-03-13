using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Modelos
{
    [Table("FACTURADETALLE")]
    public class TFacturaDetalle
    {
        [Key]
        public int codigo { get; set; }
        public int codigoFactura { get; set; }
        [ForeignKey("codigoFactura")]
        public virtual Tfactura Tfactura { get; set; }
        public int codigoproductosCliente { get; set; }
        [ForeignKey("codigoproductosCliente")]
        public virtual ITccproductoscliente ITccproductoscliente { get; set; }
        public int cantidad { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
