import { RouteObject, createBrowserRouter } from "react-router-dom";
import App from "../App";
import LoginPage from "../pages/LoginPage/LoginPage";
import RequireAdmin from "./RequireAdmin";
import AdminFestivals from "../pages/AdminFestivals/AdminFestivals";
import AdminCreateFestival from "../pages/AdminCreateFestival/AdminCreateFestival";
import Theatres from "../pages/Theatres/Theatres";
import TheatreFormPage from "../pages/TheatreFormPage/TheatreFormPage";
import ShowSearchPage from "../pages/ShowSearchPage/ShowSearchPage";
import FestivalPage from "../pages/FestivalPage/FestivalPage";
import ProfilePage from "../components/Profile/Profile";

export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App />,
        children: [
            {element: <RequireAdmin />, children: [
                {path: '/admin/festivals', element: <AdminFestivals />},
                {path: '/admin/festivals/create', element: <AdminCreateFestival />},
                {path: '/admin/festivals/:id/edit', element: <AdminCreateFestival />},
                {path: '/admin/theatres', element: <Theatres />},
                {path: '/admin/theatres/create', element: <TheatreFormPage />},
                {path: '/admin/theatres/:id/edit', element: <TheatreFormPage />},
            ]},
            {path: '/festivals/:id', element: <FestivalPage />},
            {path: '/login', element: <LoginPage />},
            {path: '/shows', element: <ShowSearchPage />},
            {path: '/profile/actor/:email', element: <ProfilePage />},

        ]
    }
];

export const router = createBrowserRouter(routes);