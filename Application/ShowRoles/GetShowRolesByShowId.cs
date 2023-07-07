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

namespace Application.ShowRoles
{
    public class GetShowRolesByShowId
    {
        public class Query : IRequest<Result<List<ActorShowRoleDto>>>
        {
            public Guid ShowId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<ActorShowRoleDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<ActorShowRoleDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var showRoles = await _context.ActorShowRoles
                    .Include(x => x.Actor)
                    .Include(x => x.Role)
                    .Include(x => x.Show)
                    .Where(x => x.ShowId == request.ShowId)
                    .ProjectTo<ActorShowRoleDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                if (showRoles == null) return Result<List<ActorShowRoleDto>>.Success(new List<ActorShowRoleDto>());

                return Result<List<ActorShowRoleDto>>.Success(showRoles);
            }
        }
    }
}