import {ErrorMessage} from "../shared/models/error.message.model";
import {OrderLine} from "./orderLine.model";

export enum OrderState {
  RECEIVED = 'OTRZYMANE',
  IN_PROGRESS = 'W TRAKCIE',
  READY_FOR_DEPARTURE = 'GOTOWE DO WYJAZDU',
  SENT = 'WYSłANE',
  CANCELED = 'ANULOWANE'
}

export enum OrderStateColor {
  RECEIVED = 'rgba(152,227,141,0.47)',
  IN_PROGRESS = 'rgba(246,227,4,0.35)',
  READY_FOR_DEPARTURE = '#337DEF',
  SENT = '#F49F1C',
  CANCELED = 'grey'
}

export interface Order extends ErrorMessage {
  orderState: string;
  barcode: string;
  linesCount: number;
  readableOrderState?: string;
  pickingStart?: string;
  pickingEnd?: string;
  orderLines: OrderLine[];
}

export interface EditOrderRequest {
  id: number,
  barcode: string;
  orderState: string;
}

export interface AddOrderRequest {
  barcode: string;
  orderLines: OrderLine[];
}
