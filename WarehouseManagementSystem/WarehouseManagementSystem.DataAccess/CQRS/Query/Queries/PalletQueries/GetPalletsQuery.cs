using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.CQRS.Helpers;

namespace DataAccess.CQRS.Queries.PalletQueries
{
    public class GetPalletsQuery : QueryBase<List<Pallet>>
    {
        public DateTime PickingEnd { get; set; }
        public string Provider { get; set; }
        public string DeliveryName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string DepartureName { get; set; }
        public DateTime DepartureCloseTime { get; set; }

        public override async Task<List<Pallet>> Execute(WMSDatabaseContext context)
        {
            var pallets = await context.GetPallets();

            return pallets
                .FilterByPickingEnd(PickingEnd)
                .FilterByProvider(Provider)
                .FilterByDeliveryName(DeliveryName)
                .FilterByUserFirstName(UserFirstName)
                .FilterByUserLastName(UserLastName)
                .FilterByDepartureName(DepartureName)
                .FilterByDepartureCloseTime(DepartureCloseTime);
        }
    }
}
