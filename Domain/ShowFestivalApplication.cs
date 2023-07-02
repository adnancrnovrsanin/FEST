using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class ShowFestivalApplication
    {
        public Guid Id { get; set; }
        public Show Show { get; set; }
        public Guid ShowId { get; set; }
        public Festival Festival { get; set; }
        public Guid FestivalId { get; set; }
        public Theatre Theatre { get; set; }
        public Guid TheatreId { get; set; }
        public int NumberOfActors { get; set; }
        public ICollection<ShowFestivalApplicationReview> Reviews { get; set; }
    }
}