using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Schedules;
using Domain.ModelDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : BaseApiController
    {
        [HttpPut]
        public async Task<IActionResult> EditScheduleAsync(ScheduleDto schedule)
        {
            return HandleResult(await Mediator.Send(new Edit.Command {Schedule = schedule}));
        }

        [AllowAnonymous]
        [HttpGet("theatre/unappointed/{id}")]
        public async Task<IActionResult> GetUnappointedScheduleByTheatreIdAsync(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetSchedulesByTheatreId.Query {TheatreId = id}));
        }
    }
}