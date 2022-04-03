import {ErrorMessage} from "./error.message.model";

export interface Delivery extends ErrorMessage {
  id?: number;
  arrival?: string;
  name?: string;
}
