using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Audition
    {
        public Guid Id { get; set; }
        public string VideoURL { get; set; }
        public ICollection<ActorAudition> Auditioners { get; set; }
        public ICollection<AuditionReview> Reviews { get; set; }
    }
}