namespace Domain
{
    public class Audition
    {
        public Guid Id { get; set; }
        public string VideoURL { get; set; }
        public string Description { get; set; }
        public ICollection<ActorShowRoleAudition> Auditioners { get; set; }
        public ICollection<AuditionReview> Reviews { get; set; }
    }
}