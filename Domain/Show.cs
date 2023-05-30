namespace Domain
{
    public class Show
    {
        public Guid Id { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public string AdditionalInformation { get; set; }
        public ICollection<ActorShowRole> Actors { get; set; }
        public ICollection<TheatreShows> Theatres { get; set; }
        public ICollection<TheatreShowSchedule> TheatreSchedules { get; set; }
        public ICollection<ShowApplicationReview> ApplicationReviews { get; set; }
    }
}