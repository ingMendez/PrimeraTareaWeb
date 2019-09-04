using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioBase<T> : IRepository<T>, IDisposable where T : class
    {
        internal Contexto _contexto;

        public RepositorioBase()
        {
            _contexto = new Contexto();
        }

        public T Buscar(int id)
        {
            T entity;

            try
            {
                entity = _contexto.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return entity;
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }

        public bool Eliminar(int id)
        {
            bool paso = false;

            try
            {
                T Entity = _contexto.Set<T>().Find(id);
                _contexto.Set<T>().Remove(Entity);

                paso = _contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            List<T> Lista = new List<T>();
            try
            {
                Lista = _contexto.Set<T>().Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;

        }

        public bool Guardar(T entity)
        {
            bool paso = false;

            try
            {
                if (_contexto.Set<T>().Add(entity) != null)
                    paso = _contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public bool Modificar(T entity)
        {
            bool paso = false;
            try
            {
                _contexto.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
    }
}
