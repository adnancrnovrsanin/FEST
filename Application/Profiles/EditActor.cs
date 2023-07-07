using Application.Core;
using AutoMapper;
using Domain.ModelDTOs;
using FluentValidation;
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
    public class EditActor
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
               var profile = await _context.Users.SingleOrDefaultAsync(x => x.Id == request.Actor.Id);
                if (profile == null) return null;
                if (request.Actor.Name != null) profile.Name = request.Actor.Name;
                if (request.Actor.Surname != null) profile.Surname = request.Actor.Surname;
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update profile");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
