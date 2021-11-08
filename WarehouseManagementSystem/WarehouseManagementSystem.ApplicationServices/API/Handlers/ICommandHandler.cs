using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public interface ICommandHandler<TRequest, TResponse, TDomainModel> 
        where TResponse : ResponseBase<TDomainModel>, new()
    {
        Task<TResponse> PrepareResponse(TRequest request);
    }
}