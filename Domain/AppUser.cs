using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Role Role { get; set; }
        public Theatre ManagedTheatre { get; set; }

        public ICollection<ActorShowRoleAudition> Auditions { get; set; }
        public ICollection<ActorShowRole> ActingRoles { get; set; }
        public ICollection<ShowFestivalApplicationReview> ShowApplications { get; set; }
        public ICollection<AuditionReview> AuditionReviews { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}