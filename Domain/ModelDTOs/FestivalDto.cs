using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ModelDTOs
{
    public class FestivalDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public TheatreDto Organizer { get; set; }
    }
}