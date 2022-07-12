using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public interface ICommandHandler<TEntity>
    {
        Task<TEntity> HandleRequest<TRequest>(TRequest request);
    }
}