import { Theatre } from "./TheatreInterfaces";

export interface Festival {
    id: string;
    name: string;
    startDate: Date;
    endDate: Date;
    zipCode: number;
    city: string;
    organizer: Theatre | null;
}

export interface FestivalDto {
    id: string;
    name: string;
    startDate: string;
    endDate: string;
    zipCode: number;
    city: string;
    organizer: Theatre | null;
}

export interface CreateFestivalDto {
    name: string;
    startDate: string;
    endDate: string;
    zipCode: number;
    city: string;
    organizer: Theatre | null;
}