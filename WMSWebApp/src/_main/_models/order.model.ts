import {ErrorMessage} from "./error.message.model";

export interface Order extends ErrorMessage {
  orderState: string;
  barcode: string;
  linesCount: number;
}
