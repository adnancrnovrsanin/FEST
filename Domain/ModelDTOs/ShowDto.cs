using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ModelDTOs
{
    public class ShowDto
    {
        public Guid Id { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public string AdditionalInformation { get; set; }
        public List<ShowRoleDto> ShowRoles { get; set; }
        public List<ScheduleDto> Schedule { get; set; }
    }
}