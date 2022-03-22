import {ErrorMessage} from "./error.message.model";

export interface Role extends ErrorMessage {
  data : {
    id: number;
    name: string;
    salary: number;
    description: string;
  }
}
