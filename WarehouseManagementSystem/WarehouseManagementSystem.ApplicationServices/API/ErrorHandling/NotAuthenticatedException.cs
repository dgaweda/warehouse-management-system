using System;

namespace WarehouseManagementSystem.ApplicationServices.API.ErrorHandling
{
    public class NotAuthenticatedException : Exception
    {
        public NotAuthenticatedException(string msg)
        : base(msg)
        {
            
        }
    }
}