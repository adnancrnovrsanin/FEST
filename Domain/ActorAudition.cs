using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class ActorAudition
    {
        public AppUser Actor { get; set; }
        public string ActorId { get; set; }
        public Audition Audition { get; set; }
        public Guid AuditionId { get; set; }
    }
}