import {ErrorMessage} from "./error.message.model";

export interface Departure extends ErrorMessage {
  data: {
    id: number;
    name: string;
    openingTime: string;
    state: string;
    closeTime: string;
  }
}
