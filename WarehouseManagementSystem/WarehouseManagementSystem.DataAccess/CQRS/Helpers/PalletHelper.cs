﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.ApplicationServices.API.Enums;

namespace DataAccess.CQRS.Helpers
{
    public static class PalletHelper
    {
        public static async Task<List<Pallet>> GetPallets(this WMSDatabaseContext context)
        {
            return await context.Pallets
                .Include(x => x.Departure)
                .Include(x => x.Order)
                .Include(x => x.Invoice)
                    .ThenInclude(invoice => invoice.Delivery)
                .Include(x => x.User)
                    .ThenInclude(user => user.Role)
                .Include(x => x.User)
                    .ThenInclude(user => user.Seniority)
                .ToListAsync();
        }

        public static void SetProperties(this Pallet pallet, Pallet Parameter)
        {
            if (Parameter.OrderId != null)
                pallet.OrderId = Parameter.OrderId;

            if (Parameter.DepartureId != null)
                pallet.DepartureId = Parameter.DepartureId;

            if (Parameter.InvoiceId != null)
                pallet.InvoiceId = Parameter.InvoiceId;

            if (Parameter.UserId != null)
                pallet.UserId = Parameter.UserId;
        }

        public static void SetStatus(this Pallet pallet)
        {
            if (PalletIsDuringOrderPicking(pallet))
                pallet.PalletStatus = Keys.PalletStatus.DURING_ORDER_PICKING;
            else if (PalletWasSent(pallet))
                pallet.PalletStatus = Keys.PalletStatus.SENT;
            else if (PalletIsReadyForDeparture(pallet))
                pallet.PalletStatus = Keys.PalletStatus.READY_FOR_DEPARTURE;
            else if (PalletIsReadyToBeUnfolded(pallet))
                pallet.PalletStatus = Keys.PalletStatus.READY_TO_BE_UNFOLDED;
            else
                pallet.PalletStatus = Keys.PalletStatus.OPEN;
        }

        private static bool PalletIsDuringOrderPicking(Pallet pallet)
        {
            return pallet.OrderId != null && pallet.UserId != null && pallet.Order.OrderState == State.IN_PROGRESS;
        }

        private static bool PalletWasSent(Pallet pallet)
        {
            return pallet.DepartureId != null && pallet.Departure.State == StateType.CLOSED;
        }

        private static bool PalletIsReadyForDeparture(Pallet pallet) {
            return pallet.OrderId != null && pallet.Order.OrderState == State.READY_FOR_DEPARTURE;
        }

        private static bool PalletIsReadyToBeUnfolded(Pallet pallet) {
            return pallet.InvoiceId != null;
        }

        // FILTERING
        public static List<Pallet> FilterByPickingEnd(this List<Pallet> pallets, DateTime pickingEnd)
        {
            if (pickingEnd == default)
                return pallets;

            return pallets.Where(x => x.Order.PickingEnd == pickingEnd).ToList();
        }

        public static List<Pallet> FilterByProvider(this List<Pallet> pallets, string provider)
        {
            if (string.IsNullOrEmpty(provider))
                return pallets;

            return pallets.Where(x => x.Invoice.Provider == provider).ToList();
        }

        public static List<Pallet> FilterByDeliveryName(this List<Pallet> pallets, string deliveryName)
        {
            if (string.IsNullOrEmpty(deliveryName))
                return pallets;

            return pallets.Where(x => x.Invoice.Delivery.Name == deliveryName).ToList();
        }

        public static List<Pallet> FilterByUserFirstName(this List<Pallet> pallets, string userFirstName)
        {
            if (string.IsNullOrEmpty(userFirstName))
                return pallets;

            return pallets.Where(x => x.User.Name == userFirstName).ToList();
        }

        public static List<Pallet> FilterByUserLastName(this List<Pallet> pallets, string userLastName)
        {
            if (string.IsNullOrEmpty(userLastName))
                return pallets;

            return pallets.Where(x => x.User.LastName == userLastName).ToList();
        }

        public static List<Pallet> FilterByDepartureName(this List<Pallet> pallets, string departureName)
        {
            if (string.IsNullOrEmpty(departureName))
                return pallets;

            return pallets.Where(x => x.Departure.Name == departureName).ToList();
        }

        public static List<Pallet> FilterByDepartureCloseTime(this List<Pallet> pallets, DateTime departureCloseTime)
        {
            if (departureCloseTime == default)
                return pallets;

            return pallets.Where(x => x.Departure.CloseTime == departureCloseTime).ToList();
        }
    }
}
