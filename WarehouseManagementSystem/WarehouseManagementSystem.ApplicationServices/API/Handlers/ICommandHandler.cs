using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public interface ICommandHandler<TResult>
    {
        Task<TResult> HandleRequest<TRequest>(TRequest request);
    }
}