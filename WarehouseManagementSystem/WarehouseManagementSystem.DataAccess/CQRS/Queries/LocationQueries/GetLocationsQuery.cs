using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.LocationQueries
{
    public class GetLocationsQuery : QueryBase<List<Location>>
    {
        private readonly IGetEntityHelper<Location> _locations;
        public GetLocationsQuery(IGetEntityHelper<Location> locations)
        {
            _locations = locations;
        }
        public override async Task<List<Location>> Execute(WMSDatabaseContext context) => await _locations.GetFilteredData(context);
    }
}
