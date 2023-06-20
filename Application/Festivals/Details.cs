using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using Domain;
using Domain.ModelDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Festivals
{
    public class Details
    {
        public class Query : IRequest<Result<FestivalDto>> {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<FestivalDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<FestivalDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var festival = await _context.Festivals.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (festival == null) return null;

                return Result<FestivalDto>.Success(_mapper.Map<FestivalDto>(festival));
            }
        }
    }
}