import {ErrorMessage} from "./error.message.model";

export interface ProductPalletLine extends ErrorMessage {
  data: {
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
}
