﻿using Application.Core;
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
    public class TheatreManagerDetails
    {
        public class Query : IRequest<Result<TheatreManagerProfileDto>>
        {
            public string Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<TheatreManagerProfileDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<TheatreManagerProfileDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var profile = await _context.Users.Include(p => p.Photos).Include(p => p.ManagedTheatre).ProjectTo<TheatreManagerProfileDto>(_mapper.ConfigurationProvider).SingleOrDefaultAsync(u => u.Id == request.Id);
                if (profile == null) return null;
                return Result<TheatreManagerProfileDto>.Success(profile);
            }
        }
    }
}
