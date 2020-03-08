using Entity.Modelos;
using Interfaces.GeneralConfig.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Usuario
{
    public interface IDataUsuario : IBaseModel<CUsuario>
    {
        List<CUsuario> get();
    }
}
