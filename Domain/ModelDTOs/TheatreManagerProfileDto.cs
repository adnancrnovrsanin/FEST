using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ModelDTOs
{
    public class TheatreManagerProfileDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public Photo ProfilePicture { get; set; }
        public TheatreDto ManagedTheatre { get; set; }


    }
}
