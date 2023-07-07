using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using Domain.ModelDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.ActorShowRoleAuditions
{
    public class Review
    {
        public class Command : IRequest<Result<Unit>>
        {
            public AuditionReviewDto Audition { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var reviewer = await _context.Users.FindAsync(request.Audition.ReviewerId);

                var audition = await _context.ActorShowRoleAuditions
                    .Include(a => a.Actor)
                    .Include(a => a.Audition)
                    .ThenInclude(a => a.Reviews)
                    .Include(a => a.ShowRole)
                    .SingleOrDefaultAsync(a => a.AuditionId == request.Audition.AuditionId);
                
                var showRole = await _context.ShowRoles
                    .Include(s => s.PickedActor)
                    .Include(s => s.ShowRoleAuditions)
                    .ThenInclude(sra => sra.Audition)
                    .ThenInclude(a => a.Reviews)
                    .Include(s => s.Show)
                    .SingleOrDefaultAsync(s => s.Id == audition.ShowRoleId);

                if (audition == null || reviewer == null || showRole == null) return null;

                if (audition.Audition.Reviews.Any(r => r.ReviewerId == reviewer.Id))
                    return Result<Unit>.Failure("You have already reviewed this audition");
                
                if (audition.Audition.Reviews.Count == 5) return Result<Unit>.Failure("This audition has already been reviewed 5 times");

                if (showRole.ShowRoleAuditions == null) showRole.ShowRoleAuditions = new List<ActorShowRoleAudition>();
                

                if (showRole.ShowRoleAuditions.Count > 0) {
                    if (showRole.ShowRoleAuditions.Count(a => a.Audition.Reviews.Count >= 3) == 3) return Result<Unit>.Failure("Audition for this role is over");
                }

                var newAuditionReview = new AuditionReview
                {
                    ReviewerId = reviewer.Id,
                    Reviewer = reviewer,
                    Audition = audition.Audition,
                    AuditionId = audition.AuditionId,
                    Review = request.Audition.Review
                };

                audition.Audition.Reviews.Add(newAuditionReview);

                if (showRole.ShowRoleAuditions.Count(a => a.Audition.Reviews.Count >= 3) == 3) {
                    var winningActor = showRole.ShowRoleAuditions
                        .Where(a => a.Audition.Reviews.Count >= 3)
                        .OrderByDescending(a => a.Audition.Reviews.Average(r => r.Review))
                        .FirstOrDefault();

                    if (winningActor != null) {
                        showRole.PickedActor.Actor = winningActor.Actor;
                        showRole.PickedActor.ActorId = winningActor.ActorId;
                    }

                    showRole.ShowRoleAuditions.Clear();
                }

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to review audition");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}