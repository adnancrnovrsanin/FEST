namespace Domain
{
    public class TheatreShowSchedule
    {
        public Guid Id { get; set; }
        public Theatre Theatre { get; set; }
        public Show Show { get; set; }
        public Guid TheatreId { get; set; }
        public Guid ShowId { get; set; }

        public ICollection<Schedule> Schedules { get; set; }
    }
}