using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ModelDTOs
{
    public class AuditionsReviewDto
    {
        public string ReviewerId { get; set; }
        public Guid AuditionId { get; set; }
        public double Review { get; set; }
    }
}
