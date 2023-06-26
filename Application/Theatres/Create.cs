using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using Domain.ModelDTOs;
using FluentValidation;
using MediatR;
using Persistance;

namespace Application.Theatres
{
    public class Create
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
                var theatre = new Theatre {
                    Name = request.Theatre.Name,
                    Address = request.Theatre.Address,
                    PhoneNumber = request.Theatre.PhoneNumber,
                    YearOfCreation = request.Theatre.YearOfCreation
                };

                _context.Theatres.Add(theatre);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create theatre");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}