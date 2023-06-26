import { makeAutoObservable, runInAction } from "mobx";
import { Theatre } from "../common/interfaces/TheatreInterfaces";
import agent from "../api/agent";

export default class TheatreStore {
    theatres: Theatre[] = [];
    loading = false;

    constructor() {
        makeAutoObservable(this);
    }

    getTheatres = async () => {
        try {
            this.loading = true;
            const theatres = await agent.TheatreRequests.all();
            runInAction(() => {
                this.theatres = theatres;
            });
        } catch (error) {
            console.log(error);
        } finally {
            runInAction(() => {
                this.loading = false;  
            });
        }
    }
}