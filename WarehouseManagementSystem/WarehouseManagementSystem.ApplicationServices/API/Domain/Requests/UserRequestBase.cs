using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace WarehouseManagementSystem.ApplicationServices.API.Domain.Requests
{
    public abstract class UserRequestBase
    {
        public string RoleName { get; set; }
    }
}