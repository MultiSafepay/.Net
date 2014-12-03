using System;

namespace MultiSafepay
{
    [Serializable]
    internal class MultiSafepayException : Exception
    {
        public int ErrorCode { get; private set; }
        public string ErrorInfo { get; private set; }
        public Exception BaseException { get; private set; }


        public MultiSafepayException(int errorCode, string errorInfo, Exception baseException)
            : this (errorCode, errorInfo)
        {
            
            BaseException = baseException;
        }

        public MultiSafepayException(int errorCode, string errorInfo)
        {
            ErrorCode = errorCode;
            ErrorInfo = errorInfo;
        }
    }
}