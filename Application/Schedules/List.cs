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

namespace Application.Schedules
{
    public class List
    {
        public class Query : IRequest<Result<List<ScheduleDto>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<List<ScheduleDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<ScheduleDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var schedules = await _context.Schedules
                    .Include(s => s.Festival)
                    .ThenInclude(f => f.Organizer)
                    .Include(s => s.TheatreShow)
                    .Include(s => s.TheatreShow.Theatre)
                    .Include(s => s.TheatreShow.Theatre.Manager)
                    .Include(s => s.TheatreShow.Show)
                    .ProjectTo<ScheduleDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                if (schedules == null) return Result<List<ScheduleDto>>.Success(new List<ScheduleDto>());

                return Result<List<ScheduleDto>>.Success(schedules);
            }
        }
    }
}