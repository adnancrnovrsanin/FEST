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

namespace Application.ActorShowRoleAuditions
{
    public class List
    {
        public class Query : IRequest<Result<List<ActorShowRoleAuditionDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<ActorShowRoleAuditionDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<ActorShowRoleAuditionDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var audition = await _context.ActorShowRoleAuditions
                    .Include(a => a.Actor)
                    .Include(a => a.Audition)
                    .ThenInclude(a => a.Reviews)
                    .Include(a => a.ShowRole)
                    .ThenInclude(a => a.Show)
                    .ProjectTo<ActorShowRoleAuditionDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                if (audition == null) return Result<List<ActorShowRoleAuditionDto>>.Success(new List<ActorShowRoleAuditionDto>());

                return Result<List<ActorShowRoleAuditionDto>>.Success(audition);
            }
        }
    }
}