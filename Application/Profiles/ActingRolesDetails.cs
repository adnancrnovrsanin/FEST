using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    public class ActingRolesDetails
    {
        public class Query : IRequest<Result<List<ActorShowRoleDto>>>
        {
            public string Id { get; set; }
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
                var showRoles = await _context.ActorShowRoles.Include(asr => asr.Actor).ProjectTo<ActorShowRoleDto>(_mapper.ConfigurationProvider).Where(asr => asr.Actor.Id == request.Id).ToListAsync();
                if (showRoles == null) return Result<List<ActorShowRoleDto>>.Success(new List<ActorShowRoleDto>());
                return Result<List<ActorShowRoleDto>>.Success(showRoles);
            }
        }
    }
}
