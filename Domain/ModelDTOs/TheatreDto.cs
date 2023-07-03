using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ModelDTOs
{
    public class TheatreDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address {get; set;}
        public string PhoneNumber { get; set; }
        public int YearOfCreation { get; set; }
        public string ManagerId { get; set; }
        public string ManagerEmail { get; set; }
    }
}