using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using AutoMapper;
using Domain;
using Domain.ModelDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Festivals
{
    public class List
    {
        public class Query : IRequest<Result<List<FestivalDto>>> {
            
        }

        public class Handler : IRequestHandler<Query, Result<List<FestivalDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<FestivalDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var festivals = await _context.Festivals.ToListAsync();

                if (festivals == null) return Result<List<FestivalDto>>.Success(new List<FestivalDto>());

                return Result<List<FestivalDto>>.Success(_mapper.Map<List<FestivalDto>>(festivals));
            }
        }
    }
}