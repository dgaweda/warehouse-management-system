using System;

namespace WarehouseManagementSystem.ApplicationServices.API.ErrorHandling.Exceptions
{
    public class NotAuthenticatedException : Exception
    {
        public NotAuthenticatedException(string msg = "User is not authenticated.")
        : base(msg)
        { }
    }
}