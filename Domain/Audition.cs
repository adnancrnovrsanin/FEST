namespace Domain
{
    public class Audition
    {
        public Guid Id { get; set; }
        public string VideoURL { get; set; }
        public string Description { get; set; }
        public ActorShowRoleAudition ActorShowRole { get; set; }
        public ICollection<AuditionReview> Reviews { get; set; }
    }
}