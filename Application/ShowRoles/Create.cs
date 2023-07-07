using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using Domain.ModelDTOs;
using MediatR;
using Persistance;

namespace Application.ShowRoles
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ActorShowRoleDto ShowRole { get; set; }
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
                var show = await _context.Shows.FindAsync(request.ShowRole.ShowId);

                if (show == null) return null;

                var showRole = new ShowRole {
                    Name = request.ShowRole.ShowRoleName,
                    Show = show
                };

                var actorShowRole = new ActorShowRole {
                    Show = show,
                    Role = showRole,
                    Pay = request.ShowRole.Pay
                };

                _context.ShowRoles.Add(showRole);
                _context.ActorShowRoles.Add(actorShowRole);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create show role");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}