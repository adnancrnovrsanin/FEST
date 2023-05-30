namespace Domain
{
    public class ActorShowRole
    {
        public AppUser Actor { get; set; }
        public Show Show { get; set; }
        public ShowRole Role { get; set; }
        public string ActorId { get; set; }
        public Guid ShowId { get; set; }
        public Guid RoleId { get; set; }
        public double Pay { get; set; }
    }
}