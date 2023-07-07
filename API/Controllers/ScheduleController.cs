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

        [HttpGet("theatre/unappointed/{id}")]
        public async Task<IActionResult> GetUnappointedScheduleByTheatreIdAsync(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetUnappointedSchedulesByTheatreId.Query {TheatreId = id}));
        }

        [AllowAnonymous]
        [HttpGet("theatre/{id}")]
        public async Task<IActionResult> GetScheduleByTheatreIdAsync(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetSchedulesByTheatreId.Query {TheatreId = id}));
        }

        [AllowAnonymous]
        [HttpGet("festival/{id}")]
        public async Task<IActionResult> GetScheduleByFestivalIdAsync(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetSchedulesByFestivalId.Query { FestivalId = id }));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllSchedulesAsync()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScheduleByIdAsync(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query {Id = id}));
        }
    }
}