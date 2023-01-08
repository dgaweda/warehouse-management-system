import {ErrorMessage} from "../common/models/error.message.model";

export interface User extends ErrorMessage {
  id: number;
  userName: string;
  password: string;
  email?: string;
  roleKey: string | number;
  name?: string;
  lastName?: string;
  pesel?: string;
  age?: number;
  authData?: string;
}

export interface AuthenticateUser {
  username: string;
  password: string;
}
