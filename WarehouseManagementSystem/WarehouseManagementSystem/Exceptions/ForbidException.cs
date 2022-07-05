using System;

namespace DataAccess.Exceptions
{
    public class ForbidException : Exception
    {
        public ForbidException(string msg = "You don't have permission.")
           : base(msg)
        {
            
        }
        
    }
}