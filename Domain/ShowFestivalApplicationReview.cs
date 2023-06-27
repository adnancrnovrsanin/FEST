namespace Domain
{
    public class ShowFestivalApplicationReview
    {
        public AppUser Reviewer { get; set; }
        public string ReviewerId { get; set; }
        public Show Show { get; set; }
        public Guid ShowId { get; set; }
        public Guid FestivalId { get; set; }
        public Festival Festival { get; set; }    
        public bool Acceptable { get; set; }
    }
}