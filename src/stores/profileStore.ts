import { makeAutoObservable, runInAction } from "mobx";
import { ActorProfile,ReviewerProfile,ManagerProfile} from "../common/interfaces/ProfileInterfaces";
import agent from "../api/agent";


export default class ProfileStore{
    loading = false;
    actor : ActorProfile | null = null;
    reviewer : ReviewerProfile | null = null;
    manager : ManagerProfile | null = null;
    constructor(){
        makeAutoObservable(this);
    }
    getActor = async (email : string) =>{
        try {
            this.loading = true;
            const actor = await agent.ProfileRequests.actordetails(email);
             runInAction(()=>{
                this.actor = actor;
                this.loading = false;
             })
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.loading = false;
            });
        }
    }
    getReviewer = async (email : string) =>{
        try {
            this.loading = true;
            const reviewer = await agent.ProfileRequests.reviewerdetails(email);
             runInAction(()=>{
                this.reviewer = reviewer;
                this.loading = false;
             })
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.loading = false;
            });
        }
    }
    getManager = async (email : string) =>{
        try {
            this.loading = true;
            const manager = await agent.ProfileRequests.managerdetails(email);
             runInAction(()=>{
                this.manager = manager;
                this.loading = false;
             })
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.loading = false;
            });
        }
    }
    updateActor = async (actor : ActorProfile ) =>{
        try {
            this.loading = true;
            await agent.ProfileRequests.updateactor(actor)
            runInAction(()=>{
                this.getActor(actor.email)
                this.loading = false;
            })
        } catch (error) {
            runInAction(() => {
                console.log(error);
                this.loading = false;
            });

        }
    }
    updateReviewer = async (reviewer : ReviewerProfile) =>{
        try {
            this.loading = true;
            await agent.ProfileRequests.updatereviewer(reviewer)
            runInAction(()=>{
                this.getReviewer(reviewer.email)
                this.loading = false;
            })
        } catch (error) {
            runInAction(() => {
                console.log(error);
                this.loading = false;
            });

        }
    }
    updateManager = async (manager : ManagerProfile ) =>{
        try {
            this.loading = true;
            await agent.ProfileRequests.updatemanager(manager)
            runInAction(()=>{
                this.getManager(manager.email)
                this.loading = false;
            })
        } catch (error) {
            runInAction(() => {
                console.log(error);
                this.loading = false;
            });

        }
    }
}