namespace Domain
{
    public class ShowRole
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<ActorShowRole> RoleActors { get; set; }
        public ICollection<ActorShowRoleAudition> ShowRoleAuditions { get; set; }
    }
}