import {ErrorMessage} from "../shared/models/error.message.model";

export interface Invoice extends ErrorMessage {
  id: number;
  invoiceNumber?: string;
  provider?: string;
  creationDateTime?: string;
  receiptDateTime?: string;
  deliveryId?: string;
}
