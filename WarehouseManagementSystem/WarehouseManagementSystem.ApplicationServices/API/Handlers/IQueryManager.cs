using System.Threading.Tasks;

namespace WarehouseManagementSystem.ApplicationServices.API.Handlers
{
    public interface IQueryHandler<in TQuery, TResponse>
    {
        Task<TResponse> HandleQuery(TQuery query);
    }
}