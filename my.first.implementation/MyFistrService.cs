using my.first.interfaces;
using my.first.types;
using System;

namespace my.first.implementation
{
    public class MyFistrService : IMyFistrService
    {
        public string Test()
        {
            DateTime now = DateTime.Now;
            return now.ToString("dd/MM/yyyy");
        }

        public string TestWithExceptionHandler()
        {
            throw new MyFirstException(103, "Hello is a test exception handler");
        }
    }
}
