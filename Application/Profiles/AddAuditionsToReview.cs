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
    public class AddAuditionsToReview
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ReviewerProfileDto Reviewer { get; set; }
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
                var reviewer = await _context.Users.SingleOrDefaultAsync(a => a.Role == Domain.Role.REVIEWER);
                if (reviewer == null) return null;
                var audition = await _context.Auditions.SingleOrDefaultAsync(a => a.Auditioners == request.Reviewer);
                if (audition == null) return null;
                AuditionReview roleAudition = new AuditionReview
                {
                    Reviewer = reviewer,
                    Audition = audition,
                };
                _context.Add(roleAudition);
                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to create auditon to reviewer");

                return Result<Unit>.Success(Unit.Value);


            }
        }
    }
}
