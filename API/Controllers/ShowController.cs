using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ShowFestivalApplicationReviews;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowController : BaseApiController
    {
        [HttpPost("apply")]
        public async Task<IActionResult> ApplyForShow(CreateDto application)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Application = application }));
        }
    }
}