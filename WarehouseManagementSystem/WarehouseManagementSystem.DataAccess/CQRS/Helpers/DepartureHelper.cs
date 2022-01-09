using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers.DataAccess.Repository;
using DataAccess.Entities;

namespace DataAccess.CQRS.Helpers
{
    public static class DepartureHelper
    {
        public async static Task<Departure> SetState(this Departure departure)
        {
            departure.State = departure.State;
            departure.CloseTime = departure.State == StateType.CLOSED ? DateTime.Now : null;

            return departure;
        }
    }
}
