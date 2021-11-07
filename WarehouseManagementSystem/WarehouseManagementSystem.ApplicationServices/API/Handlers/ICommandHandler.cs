using DataAccess.CQRS.Commands;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Domain;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public interface ICommandHandler<TRequest, TResponse, TEntity, TDomainModel, TCommand>
    {
        Task<TDomainModel> CreateCommand(TEntity entity);
        Task<TDomainModel> CreateDomainModel(TRequest request);
        Task<TResponse> CreateResponse(TRequest request);
        Task<TDomainModel> ExecuteCommand(TCommand command);
        TDomainModel MapDomainModel(TEntity entityModel);
        Task<TDomainModel> MapRequestData(TRequest request);
        Task<TResponse> SendResponse(TRequest request);
    }
}