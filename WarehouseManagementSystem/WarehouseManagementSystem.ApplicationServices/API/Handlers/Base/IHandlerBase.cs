using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Base
{
    public interface IHandlerBase<Query, DomainModel, Response, TResult>
    {
        Task<Response> PrepareResponse();
        Task PrepareQuery();
        Task ExecuteQuery(Query query);
        void MapDomainModel();
    }
}
