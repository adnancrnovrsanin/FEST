using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Reviewers;
using Domain.ModelDTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewerController : BaseApiController
    {
        [HttpPost("review/show")]
        public async Task<IActionResult> ReviewShowAsync(ShowFestivalApplicationReviewDto showFestivalApplicationReview)
        {
            return HandleResult(await Mediator.Send(new ReviewShow.Command {ShowFestivalApplicationReview = showFestivalApplicationReview}));
        }
    }
}