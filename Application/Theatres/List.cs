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
    public class List
    {
        public class Query : IRequest<Result<List<TheatreDto>>> {
            
        }

        public class Handler : IRequestHandler<Query, Result<List<TheatreDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<TheatreDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var theatres = await _context.Theatres.ToListAsync();

                if (theatres == null) return Result<List<TheatreDto>>.Success(new List<TheatreDto>());

                return Result<List<TheatreDto>>.Success(_mapper.Map<List<TheatreDto>>(theatres));
            }
        }
    }
}