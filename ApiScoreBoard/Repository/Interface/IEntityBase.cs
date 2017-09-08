using ApiScoreBoard.Helpers;
using ApiScoreBoard.Helpers.interfaces;
using ApiScoreBoard.Resources.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiScoreBoard.Repository.Interface
{
    public interface IEntityBase<T> where T : class, IBase, new()
    {
        Task<IEnumerable<T>> AllGroupByWithIncludeAsync(Expression<Func<T, object>> groupBy, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> AllIncludingAsync(params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T GetSingle(int id);
        T GetSingle(Expression<Func<T, bool>> predicate);
        T GetSingleSorted(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> predicateOrder);
        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetSingleAsync(int id);
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
        void Commit();
    }
}
