using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public interface ICommandHandler<TEntity>
    {
        Task<TEntity> HandleRequest<TRequest>(TRequest request);
    }
}