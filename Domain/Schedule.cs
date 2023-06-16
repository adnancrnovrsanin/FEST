namespace Domain
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public DateTime TimeOfPlay { get; set; }
        public int LengthOfPlay { get; set; }
        public Festival Festival { get; set; }
        public Guid FestivalId { get; set; }

        public ICollection<TheatreShowSchedule> TheatreShows { get; set; }
    }
}