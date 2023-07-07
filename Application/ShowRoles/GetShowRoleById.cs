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
    public class GetShowRoleById
    {
        public class Query : IRequest<Result<ActorShowRoleDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<ActorShowRoleDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<ActorShowRoleDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var showRoles = await _context.ActorShowRoles
                    .Include(x => x.Actor)
                    .Include(x => x.Role)
                    .Include(x => x.Show)
                    .ProjectTo<ActorShowRoleDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (showRoles == null) return null;

                return Result<ActorShowRoleDto>.Success(showRoles);
            }
        }
    }
}