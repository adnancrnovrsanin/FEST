namespace Domain
{
    public class ActorShowRoleAudition
    {
        public AppUser Actor { get; set; }
        public string ActorId { get; set; }
        public Audition Audition { get; set; }
        public Guid AuditionId { get; set; }
        public Guid ShowRoleId { get; set; }
        public ShowRole ShowRole { get; set; }
    }
}