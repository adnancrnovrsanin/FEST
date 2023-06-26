using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain.ModelDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Auditions
{
    public class Details
    {
        public class Query : IRequest<Result<AuditionDto>> {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<AuditionDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<AuditionDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var audition = await _context.Auditions.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (audition == null) return null;

                return Result<AuditionDto>.Success(_mapper.Map<AuditionDto>(audition));
            }
        }
    }
}