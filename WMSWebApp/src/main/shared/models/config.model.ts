import {Page} from "./page.model";

export abstract class Config {
  production: boolean;
  secretKey: string;
  baseApiUrl: string;
  UserApi: {
    login: string;
    getUser: string;
  };
  OrderApi: {
    getOrders: string;
    deleteOrder: string;
    editOrder: string;
    addOrder: string;
  };

  DeliveryApi: {
    getDeliveries: string;
    addDelivery: string;
    removeDelivery: string;
    editDelivery: string;
  };

  DepartureApi: {
    getDeparture: string;
    addDeparture: string;
    editDeparture: string;
    removeDeparture: string;
  };

  InvoiceApi: {
    getInvoice: string;
    addInvoice: string;
    removeInvoice: string;
    editInvoice: string;
  };

  LocationApi: {
    getLocation: string;
    addLocation: string;
    editLocation: string;
    changeLocationCurrentAmount: string;
    setLocation: string;
    removeLocation: string;
  };

  NavigationConfig: {
    mainPages: Page[];
    loginPage: Page[];
  };
}

