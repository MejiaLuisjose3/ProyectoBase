using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.GeneralConfig.database
{
    public interface IBaseService<T> where T : class
    {
        bool Create(T entity);

        List<T> BuscarTodos();

        bool Eliminar(int entity);

        bool EliminarModelo(T entity);

        bool Actualizar(T entity);

    }
}
