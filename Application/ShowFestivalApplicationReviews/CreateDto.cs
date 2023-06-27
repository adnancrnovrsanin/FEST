using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ShowFestivalApplicationReviews
{
    public class CreateDto
    {
        public Guid FestivalId { get; set; }
        public int SerialNumber { get; set; }
        public string Name { get; set; }
        public string DirectorName { get; set; }
        public string StoryWriterName { get; set; }
        public string AdditionalInformation { get; set; }
        public int NumberOfActors { get; set; }
    }
}