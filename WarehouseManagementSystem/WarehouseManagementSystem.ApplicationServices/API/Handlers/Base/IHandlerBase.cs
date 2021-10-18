using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers.Base
{
    public interface IHandlerBase<Query, DomainModelType, Response, TResult>
    {
        Task<Response> PrepareResponseAndQuery();
        Task PrepareQuery();
        Task ExecuteQuery(Query query);
        void MapDomainModel();
    }
}
