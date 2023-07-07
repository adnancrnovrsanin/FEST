using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ActorShowRoleAuditions;
using Domain.ModelDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuditionController : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAudition(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query{Id = id}));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAudition(ActorShowRoleAuditionDto audition)
        {
            return HandleResult(await Mediator.Send(new Create.Command {Audition = audition}));
        }

        [HttpGet]
        public async Task<IActionResult> GetAuditions()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }
        
        [HttpPost("review")]
        public async Task<IActionResult> ReviewAudition(AuditionReviewDto audition)
        {
            return HandleResult(await Mediator.Send(new Review.Command {Audition = audition}));
        }
    }
}