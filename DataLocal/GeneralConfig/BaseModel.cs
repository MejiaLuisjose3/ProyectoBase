using DataLocal.Context;
using Interfaces.GeneralConfig.database;
using Interfaces.GeneralConfig.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLocal.GeneralConfig
{
    public class BaseModel<T> : IBaseModel<T> where T : class
    {
        private dbContext context;
        private IDbSet<T> dbSet;
        public BaseModel(dbContext context)
        {
            dbSet = context.Set<T>();
            this.context = context;
        }

        public bool Actualizar(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return true;
        }

        public List<T> BuscarTodos()
        {
            return dbSet.ToList();
        }

        public bool create(T entity)
        {
            try
            {
                dbSet.Add(entity);
                var valores = context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Eliminar(int codigo)
        {
            dbSet.Remove(dbSet.Find(codigo));
            context.SaveChanges();
            return true;
        }

        public bool EliminarModelo(T entity)
        {

            //dbSet.Attach(entity);
            //dbSet.Remove(entity);
            //context.SaveChanges();

            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
            return true;
        }

        public bool moverImagenes(FileStream fileStream)
        {
            throw new NotImplementedException();
        }
    }
}
