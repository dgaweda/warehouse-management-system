import {ErrorMessage} from "./error.message.model";

export enum OrderState {
  RECEIVED = 'Otrzymane',
  IN_PROGRESS = 'W trakcie',
  READY_FOR_DEPARTURE = 'Gotowe do wyjazdu',
  SENT = 'Wysłane',
  CANCELED = 'Anulowane'
}

export interface Order extends ErrorMessage {
  orderState: string;
  barcode: string;
  linesCount: number;
}
