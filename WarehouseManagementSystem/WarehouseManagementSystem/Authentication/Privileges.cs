namespace warehouse_management_system.Authentication
{
    public class Privileges
    {
        public enum Claims
        {
            ADD_DELIVERY = 1,
            EDIT_DELIVERY = 2,
            GET_DELIVERIES = 3,
            REMOVE_DELIVERY = 4,

            ADD_DEPARTURE = 5,
            EDIT_DEPARTURE = 6,
            GET_DEPARTURE = 7,
            REMOVE_DEPARTURE = 8,
                
            GET_INVOICES = 9,
            ADD_INVOICE = 10,
            EDIT_INVOICE = 11,
            REMOVE_INVOICE = 12,
            
            ADD_LOCATION = 13,
            EDIT_LOCATION_CURRENT_AMOUNT = 14,
            EDIT_LOCATION = 15,
            GET_LOCATION = 16,
            REMOVE_LOCATION = 17,
            SET_PRODUCT_LOCATION = 18,
            
            ADD_PALLET = 19,
            GET_PALLETS_BY_STATUS = 20,
            GET_PALLETS = 21,
            REMOVE_PALLET = 22,
            SET_PALLET_DESTINATION = 23,
            
            ADD_PRODUCT = 24,
            EDIT_PRODUCT = 25,
            GET_PRODUCTS = 26,
            REMOVE_PRODUCT = 27,
            
            GET_PRODUCTS_BY_PALLET_ID = 28,
            DECREASE_PRODUCT_AMOUNT = 29,
            
            ADD_ROLE = 30,
            EDIT_ROLE = 31,
            GET_ROLES = 32,
            REMOVE_ROLE = 33,
            
            ADD_SENIORITY = 34,
            EDIT_SENIORITY = 35,
            GET_SENIORITY = 36,
            
            ADD_USER = 37,
            EDIT_USER = 38,
            GET_USERS = 39,
            REMOVE_USER = 40,
        }
    }
}