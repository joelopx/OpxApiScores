using ApiScoreBoard.Models;
using ApiScoreBoard.Repository;
using ApiScoreBoard.Repository.Interface;
using ApiScoreBoard.Resources.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiScoreBoard.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IEntityBase<RequestModel> Requests { get; private set; }

        public UnitOfWork(
            ApplicationDbContext context)
        {
            _context = context;
            Requests = new EntityBase<RequestModel>(_context);    
        }

        public void Complete()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}