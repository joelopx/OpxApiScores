using ApiScoreBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ApiScoreBoard.Repository.Interface;
using System.Web;
using System.Threading.Tasks;
using System.Linq.Expressions;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ApiScoreBoard.Helpers;
using ApiScoreBoard.Helpers.interfaces;
using ApiScoreBoard.Helpers.Extensions;
using ApiScoreBoard.Resources.Interfaces;

namespace ApiScoreBoard.Repository
{
    public class EntityBase<T> : IEntityBase<T>
            where T : class,IBase, new()
    {

        private readonly ApplicationDbContext _context;

        #region Properties
        public EntityBase(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion
        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

   


        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
 

        public virtual async Task<IEnumerable<T>> AllIncludingAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return await query.ToListAsync();
        }
        public T GetSingle(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefault();
        }

        public T GetSingleSorted(Expression<Func<T, bool>> predicate, Expression<Func<T, object>> predicateOrder)
        {
            return _context.Set<T>().OrderByDescending(predicateOrder).FirstOrDefault(predicate);
        }
        public async Task<T> GetSingleAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }
        public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        public virtual async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public virtual void Add(T entity)
        {
            DbEntityEntry dbEntityEntry = _context.Entry<T>(entity);
            _context.Set<T>().Add(entity);
        }

        public virtual void Edit(T entity)
        {
            DbEntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            DbEntityEntry dbEntityEntry = _context.Entry<T>(entity);
            dbEntityEntry.State = EntityState.Deleted;
        }

        public virtual void Commit()
        {
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> AllGroupByWithIncludeAsync(Expression<Func<T, object>> groupBy, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            query = query.Include(groupBy);

            return await query.ToListAsync();
        }
    }
}