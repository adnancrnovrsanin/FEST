namespace Domain
{
    public class ShowApplicationReview
    {
        public AppUser Reviewer { get; set; }
        public string ReviewerId { get; set; }
        public Show Show { get; set; }
        public Guid ShowId { get; set; }    
        public bool Acceptable { get; set; }
    }
}