using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public interface ICommandHandler<TRequest, TResponse, TDtoModel> 
        where TResponse : ResponseBase<TDtoModel>, new()
    {
        Task<TResponse> GetResponse(TRequest request);
    }
}