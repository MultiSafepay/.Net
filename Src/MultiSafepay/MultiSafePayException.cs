using System;

namespace MultiSafepay
{
    /// <summary>
    /// A MultiSafepay exception is used to represent an error code returned from the 
    /// MultiSafepay API. The original exception can be found as the BaseException.
    /// </summary>
    [Serializable]
    public class MultiSafepayException : Exception
    {
        public int ErrorCode { get; private set; }
        public string ErrorInfo { get; private set; }
        public Exception BaseException { get; private set; }

        public MultiSafepayException()
        : base() { }

        public MultiSafepayException(string format, params object[] args)
        : base(string.Format(format, args)) { }

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