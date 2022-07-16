using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess.CQRS.Query;
using DataAccess.CQRS.Query.Queries;
using DataAccess.Extensions;
using DataAccess.Repository.PalletRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CQRS.Queries.PalletQueries
{
    public class GetPalletsQuery : QueryBase<List<Pallet>>
    {
        private readonly IPalletRepository _palletRepository;

        public GetPalletsQuery(IPalletRepository palletRepository)
        {
            _palletRepository = palletRepository;
        }

        public DateTime PickingEnd { get; set; }
        public string Provider { get; set; }
        public string DeliveryName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string DepartureName { get; set; }
        public DateTime DepartureCloseTime { get; set; }
        

        public override async Task<List<Pallet>> Execute()
        {
            return await _palletRepository.GetAll()
                .FilterByPickingEnd(PickingEnd)
                .FilterByProvider(Provider)
                .FilterByDeliveryName(DeliveryName)
                .FilterByUserFirstName(UserFirstName)
                .FilterByUserLastName(UserLastName)
                .FilterByDepartureName(DepartureName)
                .FilterByDepartureCloseTime(DepartureCloseTime)
                .ToListAsync();
        }
    }
}
