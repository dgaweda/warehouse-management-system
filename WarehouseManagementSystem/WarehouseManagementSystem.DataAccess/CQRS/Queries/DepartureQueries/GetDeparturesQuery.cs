using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.DepartureQueries
{
    public class GetDeparturesQuery : QueryBase<List<Departure>>
    {
        private readonly IGetEntityHelper<Departure> _departure;
        public GetDeparturesQuery(IGetEntityHelper<Departure> departure)
        {
            _departure = departure;
        }
        public override async Task<List<Departure>> Execute(WMSDatabaseContext context) => await _departure.GetFilteredData(context);
    }
}
