using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class TheatreShowSchedule
    {
        public Theatre Theatre { get; set; }
        public Show Show { get; set; }
        public Guid TheatreId { get; set; }
        public Guid ShowId { get; set; }
        public Schedule Schedule { get; set; }
        public Guid ScheduleId { get; set; }
    }
}