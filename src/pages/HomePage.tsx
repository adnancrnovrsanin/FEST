import CurrentShows from "../components/CurrentShows/CurrentShows";
import FeaturedShows from "../components/FeatureShows/FeatureShows";
import Footer from "../components/Footer/Footer";

const HomePage = () => {
    return (
        <div>
        <FeaturedShows/>
        <CurrentShows/>
        </div>
    );
}

export default HomePage;