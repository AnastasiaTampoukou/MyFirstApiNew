using ibank.Hosting.WebApi;
using my.first.types;
using System;

namespace my.first.controllers
{
    internal static class Extensions
    {
        internal static Response<R> SafeExecutor<R>(this bUtility.ExceptionHandler exceptionHandler, Func<R> action) where R : class
        {
            var r = exceptionHandler.HandleException(action);
            SetGenericError(r?.Item2);
            return new Response<R> { Payload = r.Item1, Exception = r.Item2 };
        }
        private static void SetGenericError(bUtility.ResponseMessage item2)
        {
            if (item2?.Category != bUtility.ErrorCategory.Technical) return;
            item2.Description = MyFirstException.UnrecognizedError.Message;
            item2.Code = MyFirstException.UnrecognizedError.CodeWithPrefix;
        }
    }
}
