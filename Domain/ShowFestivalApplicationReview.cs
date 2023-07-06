namespace Domain
{
    public class ShowFestivalApplicationReview
    {
        public Guid Id { get; set; }
        public AppUser Reviewer { get; set; }
        public string ReviewerId { get; set; }
        public ShowFestivalApplication Application { get; set; }
        public Guid ShowFestivalApplicationId { get; set; }
        public bool Acceptable { get; set; }
    }
}