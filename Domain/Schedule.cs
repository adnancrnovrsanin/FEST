using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public DateTime TimeOfPlay { get; set; }
        public int LengthOfPlay { get; set; }
    }
}