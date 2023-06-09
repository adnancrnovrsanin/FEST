namespace Domain
{
    public class Show
    {
        public Guid Id { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public string DirectorName { get; set; }
        public string StoryWriterName { get; set; }
        public int LengthOfPlay { get; set; }
        public string AdditionalInformation { get; set; }
        public ICollection<ActorShowRole> Actors { get; set; }
        public ICollection<TheatreShow> Theatres { get; set; }
        public ICollection<TheatreShowSchedule> TheatreSchedules { get; set; }
        public ICollection<ShowFestivalApplicationReview> ApplicationReviews { get; set; }
        public ICollection<ShowFestivalApplication> Applications { get; set; }
    }
}