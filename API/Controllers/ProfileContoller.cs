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
        [HttpGet("actor/{id}")]
        public async Task<ActionResult<ActorProfileDto>> GetActorAsync(Guid id)
        {
            return HandleResult(await Mediator.Send(new ActorDetails.Query { Id = id }));
        }
        [HttpGet("reviewer/{id}")]
        public async Task<ActionResult<ReviewerProfileDto>> GetReviewerAsync(Guid id)
        {
            return HandleResult(await Mediator.Send(new ReviewerDetails.Query { Id = id }));
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReviewerAsync(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
       /* [HttpPost]
        public async Task<IActionResult> AddAuditionAsync(ActorProfileDto actor)
        {
            return HandleResult(await Mediator.Send(new AddAuditions.Command { Actor = actor }));
        }
        [HttpPost]
        public async Task<IActionResult> AddAuditionToReviewAsync(ReviewerProfileDto actor)
        {
            return HandleResult(await Mediator.Send(new AddAuditionsToReview.Command { Reviewer = actor }));
        }*/
    }
}
