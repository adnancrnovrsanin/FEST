using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ShowRoles;
using Domain.ModelDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class ShowRoleController : BaseApiController
    {
        [HttpGet("show/{id}")]
        public async Task<IActionResult> GetShowRolesByShowId(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetShowRolesByShowId.Query { ShowId = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateShowRole(ActorShowRoleDto showRole)
        {
            return HandleResult(await Mediator.Send(new Create.Command { ShowRole = showRole }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetShowRoleById(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetShowRoleById.Query { Id = id }));
        }
    }
}