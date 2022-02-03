using System.Collections.Generic;
using WarehouseManagementSystem.ApplicationServices.API.Handlers.DeliveryHandlers;

namespace warehouse_management_system.Authentication
{
    public class PrivilegesDictionary
    {
        public static Dictionary<Privilege, string> Get()
        {
            return new Dictionary<Privilege, string>()
            {
                { Privilege.ADD_DELIVERY, "AddDeliveryRequest"},
                { Privilege.EDIT_DELIVERY, "EditDeliveryRequest"},
                { Privilege.GET_DELIVERIES, "GetDeliveriesRequest"},
                { Privilege.REMOVE_DELIVERY, "RemoveDeliveryRequest"},
                { Privilege.ADD_DEPARTURE, "AddDepartureRequest"},
                { Privilege.EDIT_DEPARTURE, "EditDepartureStateRequest"},
                { Privilege.GET_DEPARTURES, "GetDeparturesRequest"},
                { Privilege.REMOVE_DEPARTURE, "RemoveDepartureRequest"},
                { Privilege.ADD_INVOICE, "AddInvoiceRequest"},
                { Privilege.EDIT_INVOICE, "EditInvoiceRequest"},
                { Privilege.GET_INVOICES, "GetInvoicesRequest"},
                { Privilege.REMOVE_INVOICE, "RemoveInvoiceRequest"},
                { Privilege.ADD_LOCATION, "AddLocationRequest"},
                { Privilege.EDIT_LOCATION_CURRENT_AMOUNT, "EditLocationCurrentAmount"},
                { Privilege.EDIT_LOCATION, "EditLocationRequest"},
                { Privilege.GET_LOCATIONS, "GetLocationRequest"},
                { Privilege.REMOVE_LOCATION, "RemoveLocationRequest" },
                { Privilege.SET_PRODUCT_LOCATION, "SetProductLocationRequest"},
                { Privilege.ADD_PALLET, "AddPalletRequest"},
                { Privilege.GET_PALLETS_BY_STATUS, "GetPalletsByStatusRequest"},
                { Privilege.GET_PALLETS, "GetPalletsRequest"},
                { Privilege.REMOVE_PALLET, "RemovePalletRequest"},
                { Privilege.SET_PALLET_DESTINATION, "SetPalletDestinationRequest"},
                { Privilege.ADD_PRODUCT, "AddProductRequest"},
                { Privilege.EDIT_PRODUCT, "EditProductRequest"},
                { Privilege.GET_PRODUCTS, "GetProductsRequest"},
                { Privilege.REMOVE_PRODUCT, "RemoveProductRequest"},
                { Privilege.DECREASE_PRODUCT_AMOUNT, "DecreaseProductAmountRequest"},
                { Privilege.GET_PRODUCTS_BY_PALLET_ID, "GetProductsByPalletIdRequest"},
                { Privilege.ADD_ROLE, "AddRoleRequest"},
                { Privilege.EDIT_ROLE, "EditRoleRequest"},
                { Privilege.GET_ROLES, "GetRolesRequest"},
                { Privilege.REMOVE_ROLE, "RemoveroleRequest"},
                { Privilege.ADD_SENIORITY, "AddSeniorityRequest"},
                { Privilege.EDIT_SENIORITY, "EditSeniorityRequest"},
                { Privilege.GET_SENIORITIES, "GetSenioritiesRequest"},
                { Privilege.ADD_USER, "AddUserRequest"},
                { Privilege.EDIT_USER, "EditUserRequest"},
                { Privilege.GET_USERS, "GetUsersRequest"},
                { Privilege.REMOVE_USER, "RemoveUserRequest"}
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