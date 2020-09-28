using bUtility.Logging;
using System;

namespace my.first.api
{
    public class Global : System.Web.HttpApplication
    {
        private static readonly string _logSourceName = "MyFirstApiSource";
        private static readonly ILogger _logger = new Logger(_logSourceName);

        protected void Application_Start(object sender, EventArgs e)
        {
            Logger.SetCurrent(_logger);
            ConfigProfile.LoadConfigurationProfile();
            WebApiConfig.Configure();
        }
    }
}