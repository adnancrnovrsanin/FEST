import { Theatre } from "./TheatreInterfaces";

export interface Festival {
    id: string;
    name: string;
    startDate: Date;
    endDate: Date;
    zipCode: number;
    city: string;
    organizer: Theatre;
}