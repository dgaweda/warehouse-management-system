using System;
using Newtonsoft.Json;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests
{
    public abstract class RequestBase
    {
        [JsonIgnore]
        public virtual Guid Id { get; set; } = Guid.NewGuid();
    }
}