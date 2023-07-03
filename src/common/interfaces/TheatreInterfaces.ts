export interface Theatre {
    id: string;
    name: string;
    address: string;
    phoneNumber: string;
    yearOfCreation: number;
}

export interface CreateTheatreDto {
    name: string;
    address: string;
    phoneNumber: string;
    yearOfCreation: number;
}