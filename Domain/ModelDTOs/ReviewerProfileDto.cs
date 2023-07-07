using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ModelDTOs
{
    public class ReviewerProfileDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public ICollection<ShowFestivalApplicationReviewDto> ShowApplications { get; set; }
        public ICollection<AuditionReviewDto> AuditionReviews { get; set; }
        public Photo ProfilePicture { get; set; }
    }
}
