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

                var actorShowRole = await _context.ActorShowRoles
                    .Include(asr => asr.Role)
                    .ThenInclude(r => r.ShowRoleAuditions)
                    .SingleOrDefaultAsync(x => x.Id == request.Audition.ShowRoleId);

                if (actor == null || actorShowRole == null) return null;

                var alreadyExists = await _context.ActorShowRoleAuditions.AnyAsync(asra => asra.ActorId == request.Audition.ActorId && asra.ShowRole.Show.Id == request.Audition.ShowId);

                if (alreadyExists) return Result<Unit>.Failure("Audition already exists");

                var audition = new Audition {
                    VideoURL = request.Audition.VideoURL,
                    Description = request.Audition.Description,
                };

                var actorAudition = new ActorShowRoleAudition {
                    Actor = actor,
                    Audition = audition,
                    ShowRole = actorShowRole.Role,
                    ActorId = actor.Id,
                    ShowRoleId = actorShowRole.RoleId
                };

                audition.ActorShowRole = actorAudition;
                actorShowRole.Role.ShowRoleAuditions.Add(actorAudition);

                _context.Auditions.Add(audition);

                _context.ActorShowRoleAuditions.Add(actorAudition);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create audition");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}