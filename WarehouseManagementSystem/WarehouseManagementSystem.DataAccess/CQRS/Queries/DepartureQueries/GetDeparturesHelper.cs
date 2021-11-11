using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CQRS.Queries.DepartureQueries
{
    public class GetDeparturesHelper : IGetEntityHelper<Departure>
    {
        public string Name { get; set; }
        public DateTime OpeningTime { get; set; }
        public StateType State { get; set; }

        public async Task<List<Departure>> GetFilteredData(WMSDatabaseContext context)
        {
            var departures = await context.Departures.Where(departure => departure.State == State).ToListAsync();
            if (PropertiesAreEmpty())
                return departures;
            
            if(!string.IsNullOrEmpty(Name))
                departures = SearchByName(departures);

            if (OpeningTime != DateTime.MinValue)
                departures = SearchByOpeningTime(departures);

            return departures;
        }

        private List<Departure> SearchByName(List<Departure> departures) => departures.Where(departure => departure.Name.Contains(Name)).ToList();
        private List<Departure> SearchByOpeningTime(List<Departure> departures) => departures.Where(departure => departure.OpeningTime == OpeningTime).ToList();
        public bool PropertiesAreEmpty() => string.IsNullOrEmpty(Name) && OpeningTime == DateTime.MinValue;
    }
}
