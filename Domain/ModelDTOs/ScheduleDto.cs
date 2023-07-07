using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ModelDTOs
{
    public class ScheduleDto
    {
        public Guid Id { get; set; }
        public string? TimeOfPlay { get; set; }
        public int LengthOfPlay { get; set; }
        public Guid FestivalId { get; set; }
        public string FestivalName { get; set; }
        public Guid TheatreId { get; set; }
        public string TheatreName { get; set; }
        public Guid ShowId { get; set; }
        public string ShowName { get; set; }
        public string ShowAdditionalInformation { get; set; }
        public int NumberOfActors { get; set; }
        public string ManagerEmail { get; set; }
    }
}