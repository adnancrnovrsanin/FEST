using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ModelDTOs
{
    public class ShowApplicationReviewDto
    {
        public string ReviewerId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int ShowSerialNumber { get; set; }
        public string ShowName { get; set; }
        public string AdditionalInformation { get; set; }
    }
}