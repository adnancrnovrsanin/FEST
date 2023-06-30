using Application.ActorShowRoleAuditions;
using Application.Profiles;
using Domain;
using Domain.ModelDTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileContoller : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ActorProfileDto>>> GetActorAsync(Guid id)
        {
            return HandleResult(await Mediator.Send(new ActorDetails.Query { Id = id }));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<ReviewerProfileDto>>> GetReviewerAsync(Guid id)
        {
            return HandleResult(await Mediator.Send(new ReviewerDetails.Query { Id = id }));
        }
        [HttpPut]
        public async Task<IActionResult> EditActorAsync(ActorProfileDto actor)
        {
            return HandleResult(await Mediator.Send(new EditActor.Command { Actor = actor }));
        }
        [HttpPut]
        public async Task<IActionResult> EditReviewerAsync(ReviewerProfileDto reviewer)
        {
            return HandleResult(await Mediator.Send(new EditReviewer.Command { Reviewer = reviewer }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviewerAsync(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
