import {ErrorMessage} from "../common/models/error.message.model";

export interface ProductPalletLine extends ErrorMessage {
    id: number;
    palletBarcode: string;
    productName: string;
    productAmount: number;
    orderBarcode: string;
    departureName: string;
    invoiceNumber: string;
    userFirstName: string;
    userLastName: string;
}
