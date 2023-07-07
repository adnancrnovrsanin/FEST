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
    public class AuditionReviewDetails
    {
            public class Query : IRequest<Result<List<AuditionReviewDto>>>
            {
                public string Id { get; set; }
            }
            public class Handler : IRequestHandler<Query, Result<List<AuditionReviewDto>>>
            {
                private readonly DataContext _context;
                private readonly IMapper _mapper;

                public Handler(DataContext context, IMapper mapper)
                {
                    _context = context;
                    _mapper = mapper;
                }

                public async Task<Result<List<AuditionReviewDto>>> Handle(Query request, CancellationToken cancellationToken)
                {
                    var showRoles = await _context.AuditionReviews.Include(asr => asr.Reviewer).ProjectTo<AuditionReviewDto>(_mapper.ConfigurationProvider).Where(asr => asr.ReviewerId == request.Id).ToListAsync();
                    if (showRoles == null) return Result<List<AuditionReviewDto>>.Success(new List<AuditionReviewDto>());
                    return Result<List<AuditionReviewDto>>.Success(showRoles);
                }
            }
        }
}
