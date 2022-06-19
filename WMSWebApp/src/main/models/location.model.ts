import {ErrorMessage} from "../shared/models/error.message.model";

export interface Location extends ErrorMessage {
  id: number;
  type?: string;
  name?: string;
  currentAmount?: number;
  maxAmount?: number;
  productName?: string;
  palletId?: number;
  productId?: number;
}
