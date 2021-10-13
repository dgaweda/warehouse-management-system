using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public interface IHandlerBase<T>
    {
        T PrepareResponse();
        void PrepareDomainData();
        void GetRepositoryEntity();
    }
}
