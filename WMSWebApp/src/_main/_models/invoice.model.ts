import {ErrorMessage} from "./error.message.model";

export interface Invoice extends ErrorMessage {
  data: {
    id: number;
    invoiceNumber?: string;
    provider?: string;
    creationDateTime?: string;
    receiptDateTime?: string;
    deliveryId?: string;
  }
}
