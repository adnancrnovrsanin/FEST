using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ModelDTOs
{
    public class ActorShowRoleAuditionDto
    {
        public Guid AuditionId { get; set; }
        public string ActorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; } // Actor's email
        public string VideoURL { get; set; }
        public string Description { get; set; }
        public Guid ShowRoleId { get; set; }
        public string RoleName { get; set; }
        public Guid ShowId { get; set; }
        public string ShowName { get; set; }
        public double AverageReview { get; set; }
    }
}