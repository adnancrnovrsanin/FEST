using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Festivals;
using Domain;
using Domain.ModelDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class FestivalController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Festival>>> GetFestivalsAsync()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Festival>> GetFestivalAsync(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query{Id = id}));
        }

        [HttpPost]
        public async Task<IActionResult> CreateFestivalAsync(FestivalDto festival)
        {
            return HandleResult(await Mediator.Send(new Create.Command {Festival = festival}));
        }

        [HttpPut]
        public async Task<IActionResult> EditFestivalAsync(FestivalDto festival)
        {
            return HandleResult(await Mediator.Send(new Edit.Command {Festival = festival}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFestivalAsync(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command {Id = id}));
        }

        [HttpPost("apply")]
        public async Task<IActionResult> ApplyForFestivalAsync(ShowFestivalApplicationDto festivalApplication)
        {
            return HandleResult(await Mediator.Send(new Apply.Command {FestivalApplication = festivalApplication}));
        }

        [HttpGet("applications")]
        public async Task<ActionResult<List<ShowFestivalApplicationDto>>> GetFestivalApplicationsAsync()
        {
            return HandleResult(await Mediator.Send(new ListApplications.Query()));
        }
    }
}