using Interfaces.GeneralConfig.database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Commun.DataBase
{
    public class BaseService<T> : IBaseService<T> where T : class
    {

        private readonly IBaseModel<T> baseService;

        public BaseService(IBaseModel<T> baseService)
        {
            this.baseService = baseService;
        }

        public List<T> BuscarTodos()
        {
            try
            {
                return baseService.BuscarTodos();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Create(T entity)
        {
            try
            {
                baseService.create(entity);
                return true; 
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Eliminar(int entity)
        {
            baseService.Eliminar(entity);
            return true;
        }

        public bool EliminarModelo(T entity)
        {
            baseService.EliminarModelo(entity);
            return true;
        }

        public bool Actualizar(T entity)
        {
            baseService.Actualizar(entity);
            return true;
        }

    }
}
