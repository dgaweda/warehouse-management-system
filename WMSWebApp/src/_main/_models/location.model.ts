import {ErrorMessage} from "./error.message.model";

export interface Location extends ErrorMessage   {
  data: {
    id: number;
    type?: string;
    name?: string;
    currentAmount?: number;
    maxAmount?: number;
    productName?: string;
    palletId?: number;
    productId?: number;
  }
}
