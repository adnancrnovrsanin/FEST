using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ModelDTOs
{
    public class ShowFestivalApplicationReviewDto
    {
        public Guid ShowFestivalApplicationId { get; set; }
        public Guid ReviewerId { get; set; }
        public bool Acceptable { get; set; }
    }
}