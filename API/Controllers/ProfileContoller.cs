using Application.ActorShowRoleAuditions;
using Application.Profiles;
using Domain;
using Domain.ModelDTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : BaseApiController
    {
        [HttpGet("actor/{email}")]
        public async Task<ActionResult<ActorProfileDto>> GetActorAsync(string email)
        {
            return HandleResult(await Mediator.Send(new ActorDetails.Query { Email = email }));
        }
        [HttpGet("reviewer/{email}")]
        public async Task<ActionResult<ReviewerProfileDto>> GetReviewerAsync(string email)
        {
            return HandleResult(await Mediator.Send(new ReviewerDetails.Query { Email = email }));
        }
        [HttpGet("manager/{email}")]
        public async Task<ActionResult<ReviewerProfileDto>> GetMangaerAsync(string email)
        {
            return HandleResult(await Mediator.Send(new TheatreManagerDetails.Query { Email = email }));
        }
        [HttpPut("editactor")]
        public async Task<IActionResult> EditActorAsync(ActorProfileDto actor)
        {
            return HandleResult(await Mediator.Send(new EditActor.Command { Actor = actor }));
        }
        [HttpPut("editreviewer")]
        public async Task<IActionResult> EditReviewerAsync(ReviewerProfileDto reviewer)
        {
            return HandleResult(await Mediator.Send(new EditReviewer.Command { Reviewer = reviewer }));
        }
        [HttpPut("editmanager")]
        public async Task<IActionResult> EditManagerAsync(TheatreManagerProfileDto manager)
        {
            return HandleResult(await Mediator.Send(new EditTheatreManager.Command { TheatreManager = manager }));  
        }

    }
}
