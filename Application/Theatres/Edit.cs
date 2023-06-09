using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain.ModelDTOs;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Theatres
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public TheatreDto Theatre { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command> 
        {
            public CommandValidator()
            {
                RuleFor(x => x.Theatre).SetValidator(new TheatreValidator());
            }
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
                var theatre = await _context.Theatres.SingleOrDefaultAsync(x => x.Id == request.Theatre.Id);

                if (theatre == null) return null;

                var manager = await _context.Users.SingleOrDefaultAsync(x => x.Email == request.Theatre.ManagerEmail);

                _mapper.Map(request.Theatre, theatre);

                theatre.Manager = manager;

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to update theatre");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}