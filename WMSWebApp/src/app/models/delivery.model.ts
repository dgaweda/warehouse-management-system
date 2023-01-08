import {ErrorMessage} from "../common/models/error.message.model";

export interface Delivery extends ErrorMessage {
  id?: number;
  arrival?: string;
  name?: string;
}
