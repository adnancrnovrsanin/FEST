using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class TheatreShows
    {
        public Theatre Theatre { get; set; }
        public Show Show { get; set; }
        public Guid TheatreId { get; set; }
        public Guid ShowId { get; set; }
        public int NumberOfActors { get; set; }
    }
}