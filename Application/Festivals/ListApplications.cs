using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.ModelDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Festivals
{
    public class ListApplications
    {
        public class Query : IRequest<Result<List<ShowFestivalApplicationDto>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<List<ShowFestivalApplicationDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<ShowFestivalApplicationDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var applications = await _context.ShowFestivalApplications
                    .Include(sfa => sfa.Show)
                    .ProjectTo<ShowFestivalApplicationDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
                
                if (applications == null) return Result<List<ShowFestivalApplicationDto>>.Success(new List<ShowFestivalApplicationDto>());

                return Result<List<ShowFestivalApplicationDto>>.Success(applications);
            }
        }
    }
}