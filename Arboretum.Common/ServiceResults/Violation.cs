using System;

namespace Arboretum.Common.ServiceResults
{
    public class Violation
    {
        public Exception Exception { get; set; }
        public string Message { get; set; }

        public Violation(string message)
        {
            Message = message;
        }

        public Violation(Exception exception)
        {
            Exception = exception;
        }

        public override string ToString()
        {
            if (!String.IsNullOrWhiteSpace(Message))
            {
                return Message;
            }

            if (Exception != null)
            {
                return Exception.Message;
            }

            return base.ToString();
        }
    }
}