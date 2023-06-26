using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Theatres;
using Domain.ModelDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class TheatreController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<TheatreDto>>> GetTheatresAsync()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TheatreDto>> GetTheatreAsync(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query{Id = id}));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTheatreAsync(TheatreDto theatre)
        {
            return HandleResult(await Mediator.Send(new Create.Command {Theatre = theatre}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditTheatreAsync([FromQuery]Guid id, [FromBody]TheatreDto theatre)
        {
            theatre.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command {Theatre = theatre}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTheatreAsync(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command {Id = id}));
        }
    }
}