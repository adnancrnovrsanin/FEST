using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Domain.ModelDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles
{
    public class ReviewerDetails
    {
        public class Query : IRequest<Result<ReviewerProfileDto>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<ReviewerProfileDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<ReviewerProfileDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var profile = await _context.Users.Include(p => p.Photos).Include(p=> p.AuditionReviews).ProjectTo<ReviewerProfileDto>(_mapper.ConfigurationProvider).ToListAsync();
                if (profile == null) return null;
                return Result<ReviewerProfileDto>.Success(_mapper.Map<ReviewerProfileDto>(profile));
            }
        }
    }
}
