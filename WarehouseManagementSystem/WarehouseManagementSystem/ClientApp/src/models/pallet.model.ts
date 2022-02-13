export interface palletModel {
    id: number;
    palletStatus: string;
    barcode: string;
    orderBarcode: string;
    departureName: string;
    deliveryName: string;
    userFirstName: string;
    userLastName: string;
    products: object[];
}