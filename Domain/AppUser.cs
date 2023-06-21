using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public Role Role { get; set; }

        public ICollection<ActorAudition> Auditions { get; set; }
        public ICollection<ActorShowRole> ActingRoles { get; set; }
        public ICollection<ShowApplicationReview> ShowApplications { get; set; }
        public ICollection<AuditionReview> AuditionReviews { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}