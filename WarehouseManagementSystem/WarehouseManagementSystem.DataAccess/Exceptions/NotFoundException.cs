using System;

namespace DataAccess.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string msg = "Entity not found.")
            : base(msg)
        { }
    }
}