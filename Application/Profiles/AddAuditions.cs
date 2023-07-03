using Application.Core;
using AutoMapper;
using Domain;
using Domain.ModelDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class AddAuditions
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ActorProfileDto Actor { get; set; }
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
                var actor = await _context.Users.SingleOrDefaultAsync(a => a.Role == Domain.Role.ACTOR);
                if (actor == null) return null;
                var audition = await _context.Auditions.SingleOrDefaultAsync(a => a.Auditioners == request.Actor);
                if (audition == null) return null;
                ActorShowRoleAudition roleAudition = new ActorShowRoleAudition
                {
                    Actor = actor,
                    Audition = audition,
                };
                _context.Add(roleAudition);
                var result = await _context.SaveChangesAsync() > 0;
                if(!result) return Result<Unit>.Failure("Failed to create auditon to actor");

                return Result<Unit>.Success(Unit.Value);


            }
        }
    }
}
