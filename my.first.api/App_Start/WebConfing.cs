using bUtility.Logging;
using bUtility.WebApi;
using my.first.implementation;
using my.first.interfaces;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Web.Http;
using System.Web.Http.Filters;

namespace my.first.api
{
    public static class WebApiConfig
    {
        private static readonly Container Container = new Container();

        public static void Configure()
        {
            try
            {
                GlobalConfiguration.Configure(httpConf =>
                {
                    RegisterRoutes(httpConf);
                    RegisterLogger();
                    RegisterServices();
                    RegisterGlobalFilters(httpConf.Filters);

                });

                GlobalConfiguration.Configuration.EnsureInitialized();
                Logger.Current.Info("Application Started");
            }
            catch (Exception ex)
            {
                Logger.Current.Error(ex, "Could not initialize Application");
            }
        }

        public static void RegisterLogger()
        {
            Container.Register(() => Logger.Current, Lifestyle.Singleton);
        }

        public static void RegisterRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "API",
                "api/{controller}/{action}",
                null
            );
            Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configuration.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(Container);
        }

        public static void RegisterServices()
        {
            Container.Register<IMyFistrService, MyFistrService>(Lifestyle.Singleton);
        }

        public static void RegisterGlobalFilters(HttpFilterCollection filters)
        {
            filters.Add(new ExceptionHandlingAttribute());
            
        }
    }

}