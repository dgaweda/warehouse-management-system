import {ErrorMessage} from "./error.message.model";

export interface Order extends ErrorMessage {
  data: {
    orderState: string;
    barcode: string;
    linesCount: number;
  }
}
