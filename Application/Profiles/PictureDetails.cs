using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
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
    public class PictureDetails
    {
        public class Query : IRequest<Result<List<Photo>>>
        {
            public string Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<List<Photo>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Result<List<Photo>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var photos = await _context.Photos.Where(p => p.User.Id == request.Id).ToListAsync();
                if (photos == null) return Result<List<Photo>>.Success(new List<Photo>());
                return Result<List<Photo>>.Success(photos);
            }
        }
    }
}
