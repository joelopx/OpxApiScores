using ApiScoreBoard.App_Start;
using ApiScoreBoard.Controllers;
using ApiScoreBoard.Controllers.api;
using ApiScoreBoard.Models;
using ApiScoreBoard.Persistence;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace ApiScoreBoard
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IUnitOfWork,UnitOfWork>();
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<ISecureDataFormat<AuthenticationTicket>>();
           
            container.RegisterType<UserManager<ApplicationUser>>(
                new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(
                new HierarchicalLifetimeManager());

            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });
            container.RegisterInstance<IMapper>(config.CreateMapper());
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<AccountController>(
                new InjectionConstructor());
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}