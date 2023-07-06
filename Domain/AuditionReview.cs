namespace Domain
{
    public class AuditionReview
    {
        public AppUser Reviewer { get; set; }
        public string ReviewerId { get; set; }
        public Audition Audition { get; set; }
        public Guid AuditionId { get; set; }
        public double Review { get; set; }
    }
}