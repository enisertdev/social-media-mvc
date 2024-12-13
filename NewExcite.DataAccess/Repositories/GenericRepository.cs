using NewExcite.DataAccess.Abstract;
using NewExcite.DataAccess.Concrete.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewExcite.DataAccess.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public void Add(T entity)
        {
            using var db = new NewExciteDbContext();
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        public void Delete(T entity)
        {
            using var db = new NewExciteDbContext();
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            using var db = new NewExciteDbContext();
            return db.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            using var db = new NewExciteDbContext();
            return db.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            using var db = new NewExciteDbContext();
            db.Set<T>().Update(entity);
            db.SaveChanges();
        }
    }
}
