using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ModelDTOs
{
    public class ActorAuditionDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; } // Actor's email
        public string ActorId { get; set; }
        public Guid AuditionId { get; set; }
        public string VideoURL { get; set; }
    }
}