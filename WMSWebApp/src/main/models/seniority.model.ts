import {ErrorMessage} from "../shared/models/error.message.model";

export interface Seniority extends ErrorMessage {
    employmentDate: string;
    employmentDuration: string;
    userId: number;
    name: string;
    lastName: string;
}
