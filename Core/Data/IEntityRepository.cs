using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data
{
    public interface IEntityRepository<T> where T : class, IEntity, new ()
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T Get(string id);

        List<T> GetList();
    }
}
