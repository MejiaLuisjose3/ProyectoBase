using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Modelos
{
    [Table("PRODUCTOS")]
    public class TProductos
    {
        [Key]
        public int codigo { get; set; }
        public string codigoBarra { get; set; }
        public string nombre { get; set; }
        public int precionAnterior { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
