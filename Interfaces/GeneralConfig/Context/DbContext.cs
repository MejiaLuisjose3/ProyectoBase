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
        public dbContext() : base("EstudiarContext")
        {
            
        }

        public DbSet<CUsuario> Usuario { get; set; }
    }
}
