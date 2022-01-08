using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.CQRS.Queries.PalletQueries
{
    public class GetPalletsHelper : IGetEntityHelper<Pallet>
    {
        public DateTime PickingEnd { get; set; }
        public string Provider { get; set; }
        public string DeliveryName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string DepartureName { get; set; }
        public PalletEnum.Status PalletStatus { get; set; }
        public DateTime DepartureCloseTime { get; set; }


        public async Task<List<Pallet>> GetFilteredData(WMSDatabaseContext context)
        {
            var pallets = await context.Pallets
                .Include(x => x.Departure)
                .Include(x => x.Order)
                .Include(x => x.Invoice.Delivery)
                .Include(x => x.User)
                .Include(x => x.PalletsProducts)
                    .ThenInclude(x => x.Product)
                .ToListAsync();

            if (PropertiesAreEmpty())
                return pallets;

            if (PickingEnd != DateTime.MinValue)
                pallets = SearchByPickingEnd(pallets);

            if (string.IsNullOrEmpty(Provider))
                pallets = SearchByProvider(pallets);

            if (string.IsNullOrEmpty(DeliveryName))
                pallets = SearchByDeliveryName(pallets);

            if (string.IsNullOrEmpty(UserFirstName))
                pallets = SearchByUserFirstName(pallets);

            if (string.IsNullOrEmpty(UserLastName))
                pallets = SearchByUserLastName(pallets);

            if (string.IsNullOrEmpty(DepartureName))
                pallets = SearchByDepartureName(pallets);

            if (DepartureCloseTime != DateTime.MinValue)
                pallets = SearchByDepartureDate(pallets);

            return pallets;
        }

        public bool PropertiesAreEmpty()
        {
            var empty = true;
            var properties = CreateListOfProperties();
            foreach(var prop in properties)
            {
                if (IsFilled(prop))
                    empty = false;
            }
            return empty;
        }

        private List<object> CreateListOfProperties()
        {
            return new List<object>()
            { 
                PickingEnd,
                Provider,
                DeliveryName, 
                UserFirstName, 
                UserLastName,
                DepartureName, 
                DepartureCloseTime
            };
        }

        private bool IsFilled(object prop)
        {
            if (prop == null || (DateTime)prop == DateTime.MinValue || string.IsNullOrEmpty((string)prop))
                return false;
            return true;
        }

        private List<Pallet> SearchByPickingEnd(List<Pallet> pallets) => pallets.Where(x => x.Order.PickingEnd == PickingEnd).ToList();
        private List<Pallet> SearchByProvider(List<Pallet> pallets) => pallets.Where(x => x.Invoice.Provider == Provider).ToList();
        private List<Pallet> SearchByDeliveryName(List<Pallet> pallets) => pallets.Where(x => x.Invoice.Delivery.Name == DeliveryName).ToList();
        private List<Pallet> SearchByUserFirstName(List<Pallet> pallets) => pallets.Where(x => x.User.Name == UserFirstName).ToList();
        private List<Pallet> SearchByUserLastName(List<Pallet> pallets) => pallets.Where(x => x.User.LastName == UserLastName).ToList();
        private List<Pallet> SearchByDepartureName(List<Pallet> pallets) => pallets.Where(x => x.Departure.Name == DepartureName).ToList();
        private List<Pallet> SearchByDepartureDate(List<Pallet> pallets) => pallets.Where(x => x.Departure.CloseTime == DepartureCloseTime).ToList();
    }
}
