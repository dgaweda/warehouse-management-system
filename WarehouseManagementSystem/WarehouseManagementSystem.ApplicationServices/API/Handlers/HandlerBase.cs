using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public abstract class HandlerBase<T> : IHandlerBase<T>
    {
        public abstract T PrepareResponse();

        public abstract void PrepareDomainData();

        public abstract void GetRepositoryEntity();
    }
}
