using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Core;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Festivals
{
    public class List
    {
        public class Query : IRequest<Result<List<Festival>>> {
            
        }

        public class Handler : IRequestHandler<Query, Result<List<Festival>>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor)
            {
                _context = context;
                _userAccessor = userAccessor;
            }

            public async Task<Result<List<Festival>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var festivals = await _context.Festivals.ToListAsync();

                return Result<List<Festival>>.Success(festivals);
            }
        }
    }
}