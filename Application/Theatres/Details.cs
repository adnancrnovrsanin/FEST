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

namespace Application.Theatres
{
    public class Details
    {
        public class Query : IRequest<Result<TheatreDto>> {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<TheatreDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<TheatreDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var theatre = await _context.Theatres.Include(t => t.Manager).FirstOrDefaultAsync(x => x.Id == request.Id);

                if (theatre == null) return null;

                return Result<TheatreDto>.Success(_mapper.Map<TheatreDto>(theatre));
            }
        }
    }
}