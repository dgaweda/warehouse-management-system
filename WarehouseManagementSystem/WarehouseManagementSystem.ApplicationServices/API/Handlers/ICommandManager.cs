using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public interface ICommandHandler
    {
        Task HandleRequest<TRequest>(TRequest request);
    }
}