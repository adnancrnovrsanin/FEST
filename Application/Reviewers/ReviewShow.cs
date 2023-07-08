using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Domain;
using Domain.ModelDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Reviewers
{
    public class ReviewShow
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ShowFestivalApplicationReviewDto ShowFestivalApplicationReview { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _context = context;
                _userAccessor = userAccessor;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var reviewer = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.ShowFestivalApplicationReview.ReviewerId);

                if (reviewer == null) return null;

                if (reviewer.Role != Role.REVIEWER) return Result<Unit>.Failure("You are not a reviewer");

                var showApplication = await _context.ShowFestivalApplications
                    .Include(x => x.Reviews)
                    .SingleOrDefaultAsync(x => x.Id == request.ShowFestivalApplicationReview.ShowFestivalApplicationId);
                
                if (showApplication == null) return null;

                if (showApplication.Reviews.Any(x => x.ReviewerId == reviewer.Id)) return Result<Unit>.Failure("You have already reviewed this show");

                var review = showApplication.Reviews.FirstOrDefault(x => x.ReviewerId == reviewer.Id);

                if (review == null)
                {
                    review = new ShowFestivalApplicationReview
                    {
                        Reviewer = reviewer,
                        Application = showApplication,
                        Acceptable = request.ShowFestivalApplicationReview.Acceptable
                    };

                    showApplication.Reviews.Add(review);
                    _context.ShowFestivalApplicationReviews.Add(review);
                }
                else
                {
                    review.Acceptable = request.ShowFestivalApplicationReview.Acceptable;
                    _context.ShowFestivalApplicationReviews.Update(review);
                }

                await _context.SaveChangesAsync();

                if (showApplication.Reviews.Count(x => x.Acceptable == true) >= 2) {
                    var festival = await _context.Festivals.SingleOrDefaultAsync(x => x.Id == showApplication.FestivalId);

                    if (festival == null) return null;

                    var show = await _context.Shows.SingleOrDefaultAsync(x => x.Id == showApplication.ShowId);

                    if (show == null) return null;

                    var theatre = await _context.Theatres.SingleOrDefaultAsync(x => x.Id == showApplication.TheatreId);

                    if (theatre == null) return null;

                    var theatreShow = new TheatreShow {
                        Theatre = theatre,
                        Show = show,
                        TheatreId = theatre.Id,
                        ShowId = show.Id,
                        NumberOfActors = showApplication.NumberOfActors
                    };

                    var theatreShowSchedule = new TheatreShowSchedule {
                        Theatre = theatre,
                        Show = show,
                        ShowId = show.Id,
                        TheatreId = theatre.Id,
                        Schedules = new List<Domain.Schedule>()
                    };

                    var schedule = new Domain.Schedule {
                        LengthOfPlay = show.LengthOfPlay,
                        TimeOfPlay = null,
                        Festival = festival,
                        FestivalId = festival.Id,
                        TheatreShowScheduleId = theatreShowSchedule.Id,
                        TheatreShow = theatreShowSchedule
                    };

                    theatreShowSchedule.Schedules.Add(schedule);

                    _context.TheatreShows.Add(theatreShow);
                    _context.TheatreShowSchedules.Add(theatreShowSchedule);
                    _context.Schedules.Add(schedule);
                    _context.ShowFestivalApplicationReviews.RemoveRange(showApplication.Reviews);
                    _context.ShowFestivalApplications.Remove(showApplication);

                    var result = await _context.SaveChangesAsync() > 0;

                    if (!result) return Result<Unit>.Failure("Failed to review show");

                    return Result<Unit>.Success(Unit.Value);
                }

                var resultFinal = await _context.SaveChangesAsync() > 0;

                if (!resultFinal) return Result<Unit>.Failure("Failed to review show");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}