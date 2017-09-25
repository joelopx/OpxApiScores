using ApiScoreBoard.Models;
using ApiScoreBoard.Repository.Interface;
using ApiScoreBoard.Resources.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiScoreBoard.Persistence
{
    public interface IUnitOfWork:IDisposable
    {
        UserManager<ApplicationUser> UserManager { get; }
        IEntityBase<RequestModel> Requests { get;}
        IEntityBase<ResponseModel> Responses { get; }
        IUserRepository Users { get; }
        void Complete();
    }
}
