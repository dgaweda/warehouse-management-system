export enum DeliveryApiUrl {
    getDelivery = '/Delivery/Get',
    addDelivery = '/Delivery/Add',
    removeDelivery = '/Delivery/Remove',
    editDelivery = '/Delivery/Edit'
}

export enum DepartureApiUrl {
    getDeparture = '/Departure/Get',
    addDeparture = '/Departure/Add',
    editDeparture = '/Departure/Edit',
    removeDeparture = '/Departure/Remove'
}

export enum InvoiceApiUrl {
    getInvoice = '/Invoice/Get',
    addInvoice = '/Invoice/Add',
    removeInvoice = '/Invoice/Remove',
    editInvoice = '/Invoice/Edit'
}

export enum LocationApiUrl {
    getLocation = '/Location/Get',
    addLocation = '/Location/Add',
    editLocation = '/Location/Edit',
    changeLocationCurrentAmount = '/Location/Edit/CurrentAmount',
    setLocation = '/Location/Set',
    removeLocation = '/Location/Remove'
}