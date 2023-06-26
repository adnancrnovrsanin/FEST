import { makeAutoObservable, runInAction } from "mobx";
import { Festival } from "../common/interfaces/FestivalInterfaces";
import agent from "../api/agent";

export default class FestivalStore {
    festivals: Festival[] = [];
    loading = false;

    constructor() {
        makeAutoObservable(this);
    }

    getFestivals = async () => {
        try {
            this.loading = true;
            const festivalTemp: Festival[] = [];
            const response = await agent.FestivalRequests.all();
            for (let i = 0; i < response.length; i++) {
                const festival = response[i];
                festivalTemp.push({
                    id: festival.id,
                    name: festival.name,
                    startDate: new Date(festival.startDate),
                    endDate: new Date(festival.endDate),
                    zipCode: festival.zipCode,
                    city: festival.city,
                    organizer: festival.organizer
                });
            }
            runInAction(() => {
                this.festivals = festivalTemp;
                this.loading = false;
            });
        } catch (error) {
            console.log(error);
        }
    } 

    deleteFestival = async (id: string) => {
        try {
            await agent.FestivalRequests.delete(id);
            runInAction(() => {
                this.festivals = this.festivals.filter(festival => festival.id !== id);
            });
        } catch (error) {
            console.log(error);
        }
    };
}