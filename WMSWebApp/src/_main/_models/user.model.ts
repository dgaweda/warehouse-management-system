import {ErrorMessage} from "./error.message.model";

export interface User extends ErrorMessage {
  id: number;
  userName: string;
  password: string;
  email?: string;
  roleKey?: string;
  name?: string;
  lastName?: string;
  pesel?: string;
  age?: number;
  authData?: string;
}
