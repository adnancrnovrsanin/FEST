using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Domain;
using FluentValidation;
using MediatR;
using Persistance;

namespace Application.Festivals
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Festival Festival { get; set; }
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

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var newFestival = new Festival {
                    Name = request.Festival.Name,
                    StartDate = request.Festival.StartDate,
                    EndDate = request.Festival.EndDate, 
                    City = request.Festival.City,
                    ZipCode = request.Festival.ZipCode
                };

                _context.Festivals.Add(newFestival);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create festival");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}