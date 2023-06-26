import { createContext, useContext } from "react"
import CommonStore from "./commonStore";
import UserStore from "./userStore";
import FestivalStore from "./festivalStore";

interface Store {
    commonStore: CommonStore;
    userStore: UserStore;
    festivalStore: FestivalStore;
}

export const store: Store = {
    commonStore: new CommonStore(),
    userStore: new UserStore(),
    festivalStore: new FestivalStore(),
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}