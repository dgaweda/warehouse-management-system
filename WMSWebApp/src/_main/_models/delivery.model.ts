import {ErrorMessage} from "./error.message.model";

export interface Delivery extends ErrorMessage {
  data: {
    id?: number;
    arrival?: string;
    name?: string;
  }
}
