using System;

namespace DataAccess.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string msg = "User is not authenticated.")
            : base(msg)
        {
            
        }
    }
}