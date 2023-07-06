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
    public class ShowFestivalApplicationReviewDetails
    {
        public class Query : IRequest<Result<List<ShowFestivalApplicationReviewDto>>>
        {
            public string Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<List<ShowFestivalApplicationReviewDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<ShowFestivalApplicationReviewDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var appreviews = await _context.ShowFestivalApplicationReviews.Include(asr => asr.Reviewer).ProjectTo<ShowFestivalApplicationReviewDto>(_mapper.ConfigurationProvider).Where(asr => asr.ReviewerId.ToString() == request.Id).ToListAsync();
                if (appreviews == null) return Result<List<ShowFestivalApplicationReviewDto>>.Success(new List<ShowFestivalApplicationReviewDto>());
                return Result<List<ShowFestivalApplicationReviewDto>>.Success(appreviews);
            }
        }
    }
}
