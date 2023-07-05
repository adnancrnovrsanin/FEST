using Application.ActorShowRoleAuditions;
using Application.Profiles;
using Domain;
using Domain.ModelDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : BaseApiController
    {

        [HttpGet("actor/{id}")]
        public async Task<ActionResult<ActorProfileDto>> GetActorAsync(string Id)
        {
            return HandleResult(await Mediator.Send(new ActorDetails.Query { Id = Id }));
        }
        [HttpGet("reviewer/{id}")]
        public async Task<ActionResult<ReviewerProfileDto>> GetReviewerAsync(string id)
        {
            return HandleResult(await Mediator.Send(new ReviewerDetails.Query { Id = id }));
        }
        [HttpGet("manager/{id}")]
        public async Task<ActionResult<ReviewerProfileDto>> GetMangaerAsync(string id)
        {
            return HandleResult(await Mediator.Send(new TheatreManagerDetails.Query { Id = id }));
        }
        [HttpGet("roles")]
        public async Task<ActionResult<List<ActorShowRoleDto>>> GetActingRolesAsync(string Id)
        {
            return HandleResult(await Mediator.Send(new ActingRolesDetails.Query { Id = Id }));
        }
        [HttpGet("auditionsreviewed")]
        public async Task<ActionResult<List<AuditionDto>>> GetAuditionsreviewedAsync(string Id)
        {
            return HandleResult(await Mediator.Send(new AuditionReviewedDetails.Query { Id = Id }));
        }
        [HttpGet("auditionsnotreviewed")]
        public async Task<ActionResult<List<AuditionDto>>> GetAuditionsNotReviewedAsync(string Id)
        {
            return HandleResult(await Mediator.Send(new AuditionNotReviewedDetails.Query { Id = Id }));
        }
        [HttpGet("photos")]
        public async Task<ActionResult<List<AuditionDto>>> GetPhotosAsync(string Id)
        {
            return HandleResult(await Mediator.Send(new AuditionNotReviewedDetails.Query { Id = Id }));
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
