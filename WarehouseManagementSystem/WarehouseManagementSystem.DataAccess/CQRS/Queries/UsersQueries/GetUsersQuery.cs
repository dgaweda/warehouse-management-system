using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DataAccess.CQRS.Queries
{
    public class GetUsersQuery : QueryBase<List<User>>
    {
        private readonly IGetEntityHelper<User> _employee;
        public GetUsersQuery(IGetEntityHelper<User> helper)
        {
            _employee = helper;
        }

        public override async Task<List<User>> Execute(WMSDatabaseContext context) => await _employee.GetFilteredData(context);
    }
}