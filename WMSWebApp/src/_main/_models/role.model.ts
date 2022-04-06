import {ErrorMessage} from "./error.message.model";

export interface Role extends ErrorMessage {
    id: number;
    name: string;
    salary: number;
    description: string;
}

export enum Roles {
  MANAGER = 4,
  COLLECTOR = 5,
  ADMIN = 9,
  WAREHOUSEMAN = 11
}
