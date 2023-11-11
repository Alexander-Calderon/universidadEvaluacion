using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain;
public interface IGenericRepository<T> where T : class /* where T : BaseEntity */ /* fix para que ENTIDADES intermedias con campos puedan usar el IGeneric sin tener que heredar de BaseEntity, se cambió por where T : class*/
{
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void Update(T entity);
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll ();
    IEnumerable<T> Find(Expression<Func<T,bool>> expression);
    //  Task<(int totalRegistros, IEnumerable<T> registros)> Paginacion(int pageIndex, int pageSize, string search);  

}
