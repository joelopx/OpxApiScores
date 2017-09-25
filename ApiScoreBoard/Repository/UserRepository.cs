using ApiScoreBoard.Models;
using ApiScoreBoard.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ApiScoreBoard.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<ApplicationUser> GetAll()
        {
            return _context.Users
                .Include(u => u.Roles)
                .AsEnumerable();
        }

        public ApplicationUser GetSingle(string id)
        {
            return _context.Users.Where(u => u.Id == id).FirstOrDefault();
        }
        //public QueryResult<ApplicationUser> GetAll(IQueryObject queryObj)
        //{
        //    var result = new QueryResult<ApplicationUser>();

        //    var query = _context.Users.Include(u => u.Roles).AsQueryable<ApplicationUser>();
        //    query = query.ApplyFiltering(queryObj);
        //    query = query.ApplyOrdering(queryObj);
        //    result.TotalItems = query.Count();

        //    if (queryObj.Paginate)
        //        query = query.ApplyPaging(queryObj);

        //    result.Items = query.AsEnumerable();

        //    return result;
        //}
        public ApplicationUser GetSingle(Expression<Func<ApplicationUser, bool>> predicate, params Expression<Func<ApplicationUser, object>>[] includeProperties)
        {
            IQueryable<ApplicationUser> query = _context.Set<ApplicationUser>();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate).FirstOrDefault();
        }

        //public ApplicationRole GetUserRole(Expression<Func<ApplicationRole, bool>> predicate, params Expression<Func<ApplicationRole, object>>[] includeProperties)
        //{

        //    IQueryable<ApplicationRole> query = _context.Set<ApplicationRole>();
        //    foreach (var includeProperty in includeProperties)
        //    {
        //        query = query.Include(includeProperty);
        //    }

        //    return query.Where(predicate).FirstOrDefault();
        //}
    }

}