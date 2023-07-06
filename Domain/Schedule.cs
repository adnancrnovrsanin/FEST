namespace Domain
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public DateTime? TimeOfPlay { get; set; }
        public int LengthOfPlay { get; set; }
        public Festival Festival { get; set; }
        public Guid FestivalId { get; set; }
        public Guid TheatreShowScheduleId { get; set; }
        public TheatreShowSchedule TheatreShow { get; set; }
    }
}