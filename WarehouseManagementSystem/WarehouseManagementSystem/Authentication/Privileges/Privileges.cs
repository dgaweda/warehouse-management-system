using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace warehouse_management_system.Authentication
{
    public static class Privileges
    {
        public static string Get(Privilege key)
        {
            var privileges = Get();
            return privileges.GetValueOrDefault(key);
        }
        public static Dictionary<Privilege, string> Get()
        {
            return new Dictionary<Privilege, string>()
            {
                { Privilege.ADD_DELIVERY, "AddDelivery" },
                { Privilege.EDIT_DELIVERY, "EditDelivery" },
                { Privilege.GET_DELIVERIES, "GetDeliveries" },
                { Privilege.REMOVE_DELIVERY, "RemoveDelivery" },
                { Privilege.ADD_DEPARTURE, "AddDeparture" },
                { Privilege.EDIT_DEPARTURE, "EditDepartureState" },
                { Privilege.GET_DEPARTURES, "GetDepartures" },
                { Privilege.REMOVE_DEPARTURE, "RemoveDeparture" },
                { Privilege.ADD_INVOICE, "AddInvoice" },
                { Privilege.EDIT_INVOICE, "EditInvoice" },
                { Privilege.GET_INVOICES, "GetInvoices" },
                { Privilege.REMOVE_INVOICE, "RemoveInvoice" },
                { Privilege.ADD_LOCATION, "AddLocation" },
                { Privilege.EDIT_LOCATION_CURRENT_AMOUNT, "EditLocationCurrentAmount" },
                { Privilege.EDIT_LOCATION, "EditLocation" },
                { Privilege.GET_LOCATIONS, "GetLocation" },
                { Privilege.REMOVE_LOCATION, "RemoveLocation" },
                { Privilege.SET_PRODUCT_LOCATION, "SetProductLocation" },
                { Privilege.ADD_PALLET, "AddPallet" },
                { Privilege.GET_PALLETS_BY_STATUS, "GetPalletsByStatus" },
                { Privilege.GET_PALLETS, "GetPallets" },
                { Privilege.REMOVE_PALLET, "RemovePallet" },
                { Privilege.SET_PALLET_DESTINATION, "SetPalletDestination" },
                { Privilege.ADD_PRODUCT, "AddProduct" },
                { Privilege.EDIT_PRODUCT, "EditProduct" },
                { Privilege.GET_PRODUCTS, "GetProducts" },
                { Privilege.REMOVE_PRODUCT, "RemoveProduct" },
                { Privilege.DECREASE_PRODUCT_AMOUNT, "DecreaseProductAmount" },
                { Privilege.GET_PRODUCTS_BY_PALLET_ID, "GetProductsByPalletId" },
                { Privilege.ADD_ROLE, "AddRole" },
                { Privilege.EDIT_ROLE, "EditRole" },
                { Privilege.GET_ROLES, "GetRoles" },
                { Privilege.REMOVE_ROLE, "RemoveRole" },
                { Privilege.ADD_SENIORITY, "AddSeniority" },
                { Privilege.EDIT_SENIORITY, "EditSeniority" },
                { Privilege.GET_SENIORITIES, "GetSeniorities" },
                { Privilege.ADD_USER, "AddUser" },
                { Privilege.EDIT_USER, "EditUser" },
                { Privilege.GET_USERS, "GetUsers" },
                { Privilege.REMOVE_USER, "RemoveUser" }
            };
        }
    }
    
    public enum Privilege
    {
        ADD_DELIVERY,
        EDIT_DELIVERY,
        GET_DELIVERIES,
        REMOVE_DELIVERY,

        ADD_DEPARTURE,
        EDIT_DEPARTURE,
        GET_DEPARTURES,
        REMOVE_DEPARTURE,
                
        GET_INVOICES,
        ADD_INVOICE,
        EDIT_INVOICE,
        REMOVE_INVOICE,
            
        ADD_LOCATION,
        EDIT_LOCATION_CURRENT_AMOUNT,
        EDIT_LOCATION,
        GET_LOCATIONS,
        REMOVE_LOCATION,
        SET_PRODUCT_LOCATION,
            
        ADD_PALLET,
        GET_PALLETS_BY_STATUS,
        GET_PALLETS,
        REMOVE_PALLET,
        SET_PALLET_DESTINATION,
            
        ADD_PRODUCT,
        EDIT_PRODUCT,
        GET_PRODUCTS,
        REMOVE_PRODUCT,
            
        GET_PRODUCTS_BY_PALLET_ID,
        DECREASE_PRODUCT_AMOUNT,
            
        ADD_ROLE,
        EDIT_ROLE,
        GET_ROLES,
        REMOVE_ROLE,
            
        ADD_SENIORITY,
        EDIT_SENIORITY,
        GET_SENIORITIES,
            
        ADD_USER,
        EDIT_USER,
        GET_USERS,
        REMOVE_USER,
    }
}