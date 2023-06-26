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

namespace Application.Festivals
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public FestivalDto Festival { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command> 
        {
            public CommandValidator()
            {
                RuleFor(x => x.Festival).SetValidator(new FestivalValidator());
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
                var theatre = await _context.Theatres.FindAsync(request.Festival.Organizer.Id);

                if (theatre == null) return null;

                var festival = new Festival {
                    Name = request.Festival.Name,
                    StartDate = DateTime.Parse(request.Festival.StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind),
                    EndDate = DateTime.Parse(request.Festival.EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind),
                    ZipCode = request.Festival.ZipCode,
                    City = request.Festival.City,
                    Organizer = theatre,
                };

                _context.Festivals.Add(festival);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create festival");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}