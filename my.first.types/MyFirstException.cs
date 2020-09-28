using System;
namespace my.first.types
{
    public class MyFirstException : Exception
    {
        private static readonly string ExceptionCodePrefix = "BKSR";
        public string Code { get; set; }

        public MyFirstException(int code, string msg) : base(msg)
        {
            this.Code = $"{code}";
        }

        public string CodeWithPrefix { get { return $"{ExceptionCodePrefix}-{Code}"; } }

        public static readonly MyFirstException UnrecognizedError = new MyFirstException(1001, "An unknown error occurred. Please contact  the developer or try again later");

    }
}
