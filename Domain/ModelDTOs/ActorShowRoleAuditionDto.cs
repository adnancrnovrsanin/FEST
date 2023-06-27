using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ModelDTOs
{
    public class ActorShowRoleAuditionDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; } // Actor's email
        public string ActorId { get; set; }
        public string VideoURL { get; set; }
        public string Description { get; set; }
        public Guid ShowRoleId { get; set; }
    }
}