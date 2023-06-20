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
                _context.Festivals.Add(_mapper.Map<Festival>(request.Festival));

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to create festival");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}