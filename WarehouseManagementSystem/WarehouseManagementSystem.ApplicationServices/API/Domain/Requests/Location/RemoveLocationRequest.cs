using MediatR;
using WarehouseManagementSystem.ApplicationServices.API.Domain.Responses.Location;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests.Location
{
    public class RemoveLocationRequest : CurrentUserContext, IRequest<RemoveLocationResponse>
    {
        public int Id { get; set; }
    }
}
