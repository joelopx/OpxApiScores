using ApiScoreBoard.Models;
using ApiScoreBoard.Repository;
using ApiScoreBoard.Repository.Interface;
using ApiScoreBoard.Resources.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiScoreBoard.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private UserStore<ApplicationUser> _store;
        public UserManager<ApplicationUser> UserManager { get; private set; }
        public IEntityBase<RequestModel> Requests { get; private set; }
        public IEntityBase<ResponseModel> Responses{ get; private set; }
        public IUserRepository Users { get; private set; }
        
        public UnitOfWork(
            ApplicationDbContext context)
        {
            _context = context;
            _store = new UserStore<ApplicationUser>(_context);
            UserManager = new UserManager<ApplicationUser>(_store);
            Requests = new EntityBase<RequestModel>(_context);
            Responses = new EntityBase<ResponseModel>(_context);
            Users = new UserRepository(_context);

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