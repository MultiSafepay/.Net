using System;

namespace MultiSafepay
{
    internal class MultiSafepayException : Exception
    {
        public int ErrorCode { get; private set; }
        public string ErrorInfo { get; private set; }
        public Exception BaseException { get; private set; }


        public MultiSafepayException(int errorCode, string errorInfo, Exception baseException)
        {
            ErrorCode = errorCode;
            ErrorInfo = errorInfo;
            BaseException = baseException;
        }
    }
}