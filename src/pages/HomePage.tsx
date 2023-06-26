import CurrentShows from "../components/CurrentShows/CurrentShows";
import FeaturedShows from "../components/FeatureShows/FeatureShows";
import HeroSection from "../components/Hero/Hero";
import ProfilePage from "./ProfilePage/ProfilePage";

const HomePage = () => {
    return (
        <div>
         <HeroSection/>
        <FeaturedShows/>
        <CurrentShows/>
        </div>
    );
}

export default HomePage;