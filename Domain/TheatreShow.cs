namespace Domain
{
    public class TheatreShow
    {
        public Theatre Theatre { get; set; }
        public Show Show { get; set; }
        public Guid TheatreId { get; set; }
        public Guid ShowId { get; set; }
        public int NumberOfActors { get; set; }
    }
}