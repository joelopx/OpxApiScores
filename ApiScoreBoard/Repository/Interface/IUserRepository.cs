using ApiScoreBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApiScoreBoard.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> GetAll();
        ApplicationUser GetSingle(string id);
        ApplicationUser GetSingle(Expression<Func<ApplicationUser, bool>> predicate, params Expression<Func<ApplicationUser, object>>[] includeProperties);
        //ApplicationRole GetUserRole(Expression<Func<ApplicationRole, bool>> predicate, params Expression<Func<ApplicationRole, object>>[] includeProperties);
    }
}
