using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.GeneralConfig.database
{
    public interface IBaseModel<T> where T : class
    {
        bool create(T entity);
        List<T> BuscarTodos();
        bool Eliminar(int entity);
        bool EliminarModelo(T entity);
        bool Actualizar(T entity);

        bool moverImagenes(FileStream fileStream);
    }
}
