using ApiScoreBoard.App_Start;
using ApiScoreBoard.Persistence;
using AutoMapper;
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
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MapperProfile());
            });
            container.RegisterInstance<IMapper>(config.CreateMapper());
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}