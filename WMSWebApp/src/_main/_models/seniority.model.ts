import {ErrorMessage} from "./error.message.model";

export interface Seniority extends ErrorMessage {
  data: {
    employmentDate: string;
    employmentDuration: string;
    userId: number;
    name: string;
    lastName: string;
  }
}
