using bUtility.Logging;
using ibank.Hosting.WebApi;
using my.first.interfaces;
using my.first.types;
using System.Web.Http;

namespace my.first.controllers
{
    public class MyFirstController : ApiController
    {
        private readonly ILogger _logger;
        private readonly IMyFistrService _myFirstService;
        private readonly bUtility.ExceptionHandler _exceptionHandler;

        public MyFirstController(ILogger logger, IMyFistrService myFistrService)
        {
            _logger = logger;
            _myFirstService = myFistrService;
            _exceptionHandler = new bUtility.ExceptionHandler(logger, ex => (ex as MyFirstException)?.CodeWithPrefix, typeof(MyFirstException));
        }

        [HttpGet]
        public string Test()
        {
            _logger.Info(_myFirstService.Test());
            return "Hello from My First API";
        }

        [HttpGet]
        public Response<string> TestWithExceptionHandler()
        {
            return _exceptionHandler.SafeExecutor<string>(() => _myFirstService.TestWithExceptionHandler());
        }


    }
}
