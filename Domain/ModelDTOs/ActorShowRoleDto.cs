using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ModelDTOs
{
    public class ActorShowRoleDto
    {
        public string ShowRoleName { get; set; }
        public UserDto Actor { get; set; }
        public double Pay { get; set; }
    }
}