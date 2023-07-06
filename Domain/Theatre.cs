namespace Domain
{
    public class Theatre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int YearOfCreation { get; set; }
        public AppUser Manager { get; set; }
        public string ManagerId { get; set; }

        public ICollection<Festival> FestivalsOrganized { get; set; }
        public ICollection<TheatreShow> Shows { get; set; }
        public ICollection<TheatreShowSchedule> ShowSchedules { get; set; }
    }
}