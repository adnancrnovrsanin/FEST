using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using Domain.ModelDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.ActorShowRoleAuditions
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ActorShowRoleAuditionDto Audition { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var actor = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.Audition.ActorId);

                var actorShowRole = await _context.ActorShowRoles.SingleOrDefaultAsync(x => x.Id == request.Audition.ShowRoleId);

                if (actor == null || actorShowRole == null) return null;

                var audition = new Audition {
                    VideoURL = request.Audition.VideoURL,
                    Description = request.Audition.Description,
                };

                _context.Auditions.Add(audition);

                var actorAudition = new ActorShowRoleAudition {
                    Actor = actor,
                    Audition = audition,
                    ShowRole = actorShowRole.Role,
                    ActorId = actor.Id,
                    AuditionId = audition.Id,
                    ShowRoleId = actorShowRole.RoleId
                };

                _context.ActorShowRoleAuditions.Add(actorAudition);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create audition");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}