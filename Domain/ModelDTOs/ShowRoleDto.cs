using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ModelDTOs
{
    public class ShowRoleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ActorShowRoleDto Actor { get; set; }
    }
}