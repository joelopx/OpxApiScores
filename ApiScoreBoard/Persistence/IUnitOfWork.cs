using ApiScoreBoard.Repository.Interface;
using ApiScoreBoard.Resources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiScoreBoard.Persistence
{
    public interface IUnitOfWork:IDisposable
    {
        IEntityBase<RequestModel> Requests { get;}
        void Complete();
    }
}
