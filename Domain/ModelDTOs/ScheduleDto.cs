using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ModelDTOs
{
    public class ScheduleDto
    {
        public Guid Id { get; set; }
        public string TimeOfPlay { get; set; }
        public int LengthOfPlay { get; set; }
        public Guid FestivalId { get; set; }
        public string FestivalName { get; set; }
    }
}