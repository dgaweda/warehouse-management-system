// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

import {Config} from "../app/common/models/config.model";

class Environment implements Config {
  production = false;
  secretKey = 'h+49^J**T$F+yXw8';
  baseApiUrl = 'https://localhost:44388';
  UserApi = {
    login: '/User/Login',
    getUser: '/User/Get'
  };
  OrderApi = {
    getOrders: '/Order/Get',
    deleteOrder: '/Order/Remove',
    editOrder: '/Order/Edit',
    addOrder: '/Order/Add'
  };
  DeliveryApi = {
    getDeliveries: '/Delivery/Get',
    addDelivery: '/Delivery/Add',
    removeDelivery: '/Delivery/Remove',
    editDelivery: '/Delivery/Edit'
  };
  DepartureApi = {
    getDeparture: '/Departure/Get',
    addDeparture: '/Departure/Add',
    editDeparture: '/Departure/Edit',
    removeDeparture: '/Departure/Remove'
  };
  InvoiceApi = {
    getInvoice: '/Invoice/Get',
    addInvoice: '/Invoice/Add',
    removeInvoice: '/Invoice/Remove',
    editInvoice: '/Invoice/Edit'
  };
  LocationApi = {
    getLocation: '/Location/Get',
    addLocation: '/Location/Add',
    editLocation: '/Location/Edit',
    changeLocationCurrentAmount: '/Location/Edit/CurrentAmount',
    setLocation: '/Location/Set',
    removeLocation: '/Location/Remove'
  };

  NavigationConfig = {
    mainPages: [
      {id: 0, route: '/home', text: 'Strona Główna', icon: 'home'},
      {id: 1, route: '/order', text: 'Zamówienia', icon: 'orderedlist'},
      {id: 2, route: '/delivery', text: 'Dostawy', icon: 'hierarchy'}
    ],
    loginPage: [{id: 3, route: '/login', text: 'Logowanie', icon: 'return'}]
  };
}

export const environment = new Environment();
/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
