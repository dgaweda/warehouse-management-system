using System;

namespace DataAccess.Exceptions
{
    public class InvalidDateTimeException : Exception
    {
        public InvalidDateTimeException(string msg = "DateTime can't be default.") : base(msg)
        {
            
        }
    }
}