using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.ModelDTOs
{
    public class ActorShowRoleDto
    {
        public Guid Id { get; set; }
        public Guid ShowId { get; set; }
        public Guid RoleId { get; set; }
        public string ShowName { get; set; }
        public string ShowRoleName { get; set; }
        public UserDto Actor { get; set; }
        public double Pay { get; set; }
    }
}