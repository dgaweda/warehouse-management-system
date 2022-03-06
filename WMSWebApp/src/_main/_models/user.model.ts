export interface User {
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
