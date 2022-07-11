using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public interface ICommandHandler<TResult>
    {
        Task<TResponse> HandleRequest<TRequest, TResponse>(TRequest request)
            where TResponse : ResponseBase<TResult>, new();
    }
}