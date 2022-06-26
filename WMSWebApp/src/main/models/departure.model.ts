import {ErrorMessage} from "../shared/models/error.message.model";

export interface Departure extends ErrorMessage {
  id: number;
  name: string;
  openingTime: string;
  state: string;
  closeTime: string;
}
