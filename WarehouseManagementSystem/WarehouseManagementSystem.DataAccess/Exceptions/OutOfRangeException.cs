using System;

namespace DataAccess.Exceptions
{
    public class OutOfRangeException : Exception
    {
        public OutOfRangeException(string msg = "Out of range exception"): base(msg)
        {
            
        }
    }
}