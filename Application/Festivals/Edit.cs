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
    public class Edit
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
                var festival = await _context.Festivals.FindAsync(request.Festival.Id);

                if (festival == null) return null;

                _mapper.Map(request.Festival, festival);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to update festival");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}