using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain
{
    public class ResponseBase<T> : ErrorResponseBase
    {
        public T Data { get; set; }
    }
}
