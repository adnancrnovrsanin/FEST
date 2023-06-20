import { makeAutoObservable } from "mobx";
import { User } from "../common/interfaces/UserInterfaces";

export default class UserStore {
    user: User | null = null;
    loading = false;

    constructor() {
        makeAutoObservable(this);
    }

    get isLoggedIn() {
        return !!this.user;
    }

    
}