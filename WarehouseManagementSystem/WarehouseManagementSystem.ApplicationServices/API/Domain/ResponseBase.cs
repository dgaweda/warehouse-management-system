
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain
{
    public class ResponseBase<T>
    {
        public T Response { get; set; }
    }
}
