namespace Domain
{
    public class Festival
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public Theatre Organizer { get; set; }
        public ICollection<Schedule> ShowSchedules { get; set; }
        public ICollection<ShowFestivalApplication> ShowApplications { get; set; }
    }
}