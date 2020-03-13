using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Modelos
{
    [Table("FACTURA")]
    public class Tfactura
    {
        [Key]
        public int codigo { get; set; }
        public int codigoCliente { get; set; }
        [ForeignKey("codigoCliente")]
        public virtual TClientes TClientes { get; set; }
        public string estatus { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
